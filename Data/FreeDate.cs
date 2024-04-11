namespace TollFeeCalculatorApp.Config;

public  class FreeDates
{
    public  List<DateTime> Dates { get; }

    public FreeDates()
    {
        Dates = new List<DateTime>
        {
            // Add specific dates
            new DateTime(2013, 1, 1),
            new DateTime(2013, 3, 28),
            new DateTime(2013, 3, 29),
            new DateTime(2013, 4, 1),
            new DateTime(2013, 4, 30),
            new DateTime(2013, 5, 1),
            new DateTime(2013, 5, 8),
            new DateTime(2013, 5, 9),
            new DateTime(2013, 6, 5),
            new DateTime(2013, 6, 6),
            new DateTime(2013, 6, 21),
            new DateTime(2013, 11, 1),
            new DateTime(2013, 12, 24),
            new DateTime(2013, 12, 25),
            new DateTime(2013, 12, 26),
            new DateTime(2013, 12, 31)
        };

        // Add all dates of July 2013
        for (int day = 1; day <= DateTime.DaysInMonth(2013, 7); day++)
        {
            Dates.Add(new DateTime(2013, 7, day));
        }

    }
}