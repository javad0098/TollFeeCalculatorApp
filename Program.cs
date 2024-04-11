using Microsoft.Extensions.DependencyInjection;

namespace TollFeeCalculatorApp;

using TollFeeCalculatorApp;

class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();

        // Create a new Startup instance and configure services
        var startup = new Startup();
        startup.ConfigureServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        var tollFeeService = serviceProvider.GetService<ITollFeeService>();        

        // Example usage
        var vehicle = new Car();
                
        if (tollFeeService != null)
        {
            DateTime[] Freedates = new DateTime[]
            {
                new DateTime(2023, 4, 1, 6, 0, 0),
                new DateTime(2023, 4, 1, 6, 30, 0),
                new DateTime(2023, 4, 1, 7, 0, 0)
            };
            var fee = tollFeeService.GetTollFee(vehicle, Freedates);
            Console.WriteLine($"Toll fee for the given date for free dates: {fee == 0}");
            
            DateTime[] dates = new DateTime[]
            {
                new DateTime(2013, 4, 2, 6, 0, 0), // Start of the day
                new DateTime(2013, 4, 2, 7, 59, 0), // One minute before the next hour
                new DateTime(2013, 4, 2, 8, 59, 0), // One minute before the next hour
                new DateTime(2013, 4, 2, 9, 59, 0), // One minute before the next hour
                new DateTime(2013, 4, 2, 11, 0, 0), // Start of the day
                new DateTime(2013, 4, 2, 12, 0, 0), // Start of the day
                new DateTime(2013, 4, 2, 13, 0, 0), // Start of the day
                new DateTime(2013, 4, 2, 14, 59, 0), // One minute before the next hour
                new DateTime(2013, 4, 2, 16, 59, 0), // One minute before the next hour
                new DateTime(2013, 4, 2, 18, 59, 0) // One minute before the next hour

            };
            
            var getTollnewFee = tollFeeService.GetTollFee(vehicle, dates);
            Console.WriteLine($"Toll fee for the given date for GetTollFee dates: {getTollnewFee}");
        }

        
    }
}
