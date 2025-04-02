namespace DIP;

public class Clock
{
    public virtual DateOnly Today()
    {
        return DateOnly.FromDateTime(DateTime.Today);
    }
}