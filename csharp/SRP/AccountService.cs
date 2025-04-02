using System.Globalization;

namespace SRP;

public class AccountService
{
    private const string StatementHeader = "DATE | AMOUNT | BALANCE";
    private const string DateFormat = "dd/MM/yyyy";
    private const string AmountFormat = "#.00";

    private readonly TransactionRepository _transactionRepository;
    private readonly Clock _clock;
    private readonly Console _console;

    public AccountService(TransactionRepository transactionRepository, Clock clock, Console console)
    {
        _transactionRepository = transactionRepository;
        _clock = clock;
        _console = console;
    }

    public void Deposit(int amount)
    {
        _transactionRepository.Add(TransactionWith(amount));
    }

    public void Withdraw(int amount)
    {
        _transactionRepository.Add(TransactionWith(-amount));
    }

    public void PrintStatement()
    {
        PrintHeader();
        PrintTransactions();
    }

    private void PrintHeader()
    {
        PrintLine(StatementHeader);
    }

    private void PrintTransactions()
    {
        var transactions = _transactionRepository.All();
        var balance = 0;
        transactions
            .Select(transaction =>
            {
                balance += transaction.Amount;
                return StatementLine(transaction, balance);
            })
            .Reverse()
            .ToList()
            .ForEach(PrintLine);
    }

    private Transaction TransactionWith(int amount)
    {
        return new Transaction(_clock.Today(), amount);
    }

    private string StatementLine(Transaction transaction, int balance)
    {
        return $"{FormatDate(transaction.Date)} | {FormatNumber(transaction.Amount)} | {FormatNumber(balance)}";
    }

    private string FormatDate(DateTime date)
    {
        return date.ToString(DateFormat);
    }

    private string FormatNumber(int amount)
    {
        return amount.ToString(AmountFormat, CultureInfo.InvariantCulture);
    }

    private void PrintLine(string line)
    {
        _console.PrintLine(line);
    }
}