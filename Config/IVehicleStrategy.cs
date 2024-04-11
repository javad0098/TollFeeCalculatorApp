using TollFeeCalculatorApp.Enums;

namespace TollFeeCalculatorApp.Config;

public interface IVehicleStrategy
{ 
    public bool IsTollFreeVehicle(VehicleTypes? vehicleType);
}

public class VehicleStrategy: IVehicleStrategy
{
    public bool IsTollFreeVehicle(VehicleTypes? vehicleType)
    {
        if (!vehicleType.HasValue)
        {
            return false;
        }

        switch (vehicleType.Value)
        {
            case VehicleTypes.Motorbike:
            case VehicleTypes.Tractor:
            case VehicleTypes.Emergency:
            case VehicleTypes.Diplomat:
            case VehicleTypes.Foreign:
            case VehicleTypes.Military:
                return true;
            default:
                return false;
        }
    }
}