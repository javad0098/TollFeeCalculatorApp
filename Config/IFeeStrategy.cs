using TollFeeCalculatorApp.Data;

public interface IFeeStrategy
{
    int GetFeeByTimeSpan(TimeSpan date);
}

internal class FeeStrategy(FeeRates feeRates) : IFeeStrategy
{
    public int GetFeeByTimeSpan(TimeSpan time)
    {
        

        foreach (var rate in feeRates.Rates)
        {
            if (time >= rate.Start && time <= rate.End)
            {
                return rate.Fee;
            }
        }

        return 0; // Default to 0 for any other time
    }

}