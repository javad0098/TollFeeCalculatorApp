namespace TollFeeCalculatorApp.Config;

public interface IDateStrategy
{
    bool IsFreeDate(DateTime date);
}

internal class DateStrategy : IDateStrategy
{
    private readonly FreeDates _freeDates;
    public DateStrategy(FreeDates freeDates)
    {
        _freeDates = freeDates;
    }

    public bool IsFreeDate(DateTime date)
    {

        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;
        
        return _freeDates.Dates.Contains(date);    
    }
}