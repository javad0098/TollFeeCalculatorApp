using TollFeeCalculatorApp.Config;
using TollFeeCalculatorApp.Enums;

namespace TollFeeCalculatorApp;

public interface ITollFeeService
{
    int GetTollFee(IVehicle vehicle, DateTime[] dates);
}

public class TollFeeService : ITollFeeService
{
    private readonly IFeeStrategy _feeStrategy;
    private readonly IDateStrategy _dateStrategy;
    private readonly IVehicleStrategy _vehicleStrategy;
    public TollFeeService(IDateStrategy dateStrategy, IFeeStrategy tollFeeStrategy,IVehicleStrategy vehicleStrategy)
    {
        _feeStrategy = tollFeeStrategy;
        _vehicleStrategy = vehicleStrategy;
        _dateStrategy = dateStrategy;
    }
    private int GetTollFee(VehicleTypes vehicle, DateTime date)
    {
        if (_dateStrategy.IsFreeDate(date)) return 0;
        
        if (_vehicleStrategy.IsTollFreeVehicle(vehicle)) return 0;
        
        return _feeStrategy.GetFeeByTimeSpan(date.TimeOfDay);
    }
    
    
    
    public int GetTollFee(IVehicle vehicle, DateTime[] dates)
    {
        int totalFee = 0;
        DateTime? intervalStart = null;

        foreach (DateTime date in dates)
        {
            int nextFee = GetTollFee(vehicle.GetVehicleType(), date);

            if (intervalStart.HasValue)
            {

                if (IsWithinSixtyMinuteInterval(date, intervalStart.Value))
                {
                    int tempFee = GetTollFee(vehicle.GetVehicleType(), intervalStart.Value);
                    totalFee = AdjustTotalFee(totalFee, tempFee, nextFee);
                }
                else
                {
                    totalFee += nextFee;
                }
            }
            // Update the interval start for the next iteration
            // we did not do this in old calculation
            intervalStart = date; 
        }

        return CapTotalFee(totalFee);
    }
    
    /// <summary>
    /// old calculation has not given correct value
    /// so
    /// </summary>
    /// <param name="date"></param>
    /// <param name="intervalStart"></param>
    /// <returns></returns>
    private bool IsWithinSixtyMinuteInterval(DateTime date, DateTime intervalStart)
    {
        
        // long diffInMillies = date.Millisecond - intervalStart.Millisecond;
        // long minutes = diffInMillies/1000/60;
        //
        double intervalMinutes = (date - intervalStart).TotalMinutes;
        
        return intervalMinutes <= 60;
    }
    private int AdjustTotalFee(int totalFee, int tempFee, int nextFee)
    {
        if (totalFee > 0) totalFee -= tempFee;
        if (nextFee >= tempFee) tempFee = nextFee;
        totalFee += tempFee;
        return totalFee;
    }

    private int CapTotalFee(int totalFee)
    {
        if (totalFee > 60) totalFee = 60;
        return totalFee;
    }
}