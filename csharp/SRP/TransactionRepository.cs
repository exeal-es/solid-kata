namespace SRP;

public class TransactionRepository
{
    private readonly List<Transaction> _transactions = new();

    public virtual void Add(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    public virtual List<Transaction> All()
    {
        return _transactions;
    }
}