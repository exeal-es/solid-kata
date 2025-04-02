namespace SRP;

public class Transaction
{
    private readonly DateTime _date;
    private readonly int _amount;

    public Transaction(DateTime date, int amount)
    {
        _date = date;
        _amount = amount;
    }

    public DateTime Date => _date;
    public int Amount => _amount;
}