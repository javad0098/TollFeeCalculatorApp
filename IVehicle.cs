
using TollFeeCalculatorApp.Enums;

namespace TollFeeCalculatorApp;

public interface IVehicle
{
    VehicleTypes GetVehicleType();
}

public class Car : IVehicle
{
    public VehicleTypes GetVehicleType() => VehicleTypes.Car;
}
public class Motorbike : IVehicle
{
    public VehicleTypes GetVehicleType() => VehicleTypes.Motorbike;
}


