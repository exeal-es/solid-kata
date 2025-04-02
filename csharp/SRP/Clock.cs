namespace SRP;

public class Clock
{
    public virtual DateTime Today()
    {
        return DateTime.Now;
    }
}