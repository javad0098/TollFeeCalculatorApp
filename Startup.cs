using Microsoft.Extensions.DependencyInjection;
using TollFeeCalculatorApp.Config;
using TollFeeCalculatorApp.Data;

namespace TollFeeCalculatorApp;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<FeeRates>();
        services.AddSingleton<FreeDates>();
        services.AddSingleton<IFeeStrategy, FeeStrategy>();
        services.AddSingleton<IDateStrategy, DateStrategy>();
        services.AddSingleton<IVehicleStrategy, VehicleStrategy>();

        
        services.AddSingleton<ITollFeeService>(provider =>
        {
            return new TollFeeService(
                provider.GetRequiredService<IDateStrategy>(),
                provider.GetRequiredService<IFeeStrategy>(),
                provider.GetRequiredService<IVehicleStrategy>()
                );
        });
    }
}