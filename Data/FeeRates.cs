
 namespace TollFeeCalculatorApp.Data;

 internal class FeeRates
 {
     public List<(TimeSpan Start, TimeSpan End, int Fee)> Rates { get; }

     public FeeRates()
     {
         Rates = new List<(TimeSpan Start, TimeSpan End, int Fee)>
         {
             (TimeSpan.FromHours(6), TimeSpan.FromHours(6).Add(TimeSpan.FromMinutes(30)), 8), // From 6:00 to 6:30
             (TimeSpan.FromHours(6).Add(TimeSpan.FromMinutes(30)), TimeSpan.FromHours(7), 13), // From 6:30 to 7:00
             (TimeSpan.FromHours(7), TimeSpan.FromHours(8), 18), // From 7:00 to 8
             (TimeSpan.FromHours(8), TimeSpan.FromHours(8).Add(TimeSpan.FromMinutes(30)), 13), // From 8:00 to 8:29
             (TimeSpan.FromHours(8).Add(TimeSpan.FromMinutes(30)), TimeSpan.FromHours(15), 8), // From 8:30 to 15
             (TimeSpan.FromHours(15), TimeSpan.FromHours(15).Add(TimeSpan.FromMinutes(30)), 13), // From 15 to 15:30
             //here is a bit collapse within time
             (TimeSpan.FromHours(15).Add(TimeSpan.FromMinutes(30)), TimeSpan.FromHours(17), 18), // From 15:00 to 17
             (TimeSpan.FromHours(17), TimeSpan.FromHours(17), 13), // From 17:00 to 17:59
             (TimeSpan.FromHours(18), TimeSpan.FromHours(18).Add(TimeSpan.FromMinutes(30)), 8) // From 18:00 to 18:29
         };
     }
 }