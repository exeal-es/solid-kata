using NSubstitute;

namespace SRP.Tests;

public class AccountServiceShould
{
    private const int PositiveAmount = 100;
    private const int NegativeAmount = -PositiveAmount;
    private static readonly DateTime Today = new(2017, 9, 6);
    private static readonly List<Transaction> Transactions = new()
    {
        new Transaction(new DateTime(2014, 4, 1), 1000),
        new Transaction(new DateTime(2014, 4, 2), -100),
        new Transaction(new DateTime(2014, 4, 10), 500)
    };

    private readonly Clock _clock;
    private readonly TransactionRepository _transactionRepository;
    private readonly Console _console;
    private readonly AccountService _accountService;

    public AccountServiceShould()
    {
        _clock = Substitute.For<Clock>();
        _transactionRepository = Substitute.For<TransactionRepository>();
        _console = Substitute.For<Console>();
        _accountService = new AccountService(_transactionRepository, _clock, _console);
        _clock.Today().Returns(Today);
    }

    [Fact]
    public void DepositAmountIntoTheAccount()
    {
        _accountService.Deposit(PositiveAmount);

        _transactionRepository.Received().Add(Arg.Is<Transaction>(t => 
            t.Date == Today && 
            t.Amount == PositiveAmount));
    }

    [Fact]
    public void WithdrawAmountFromTheAccount()
    {
        _accountService.Withdraw(PositiveAmount);

        _transactionRepository.Received().Add(Arg.Is<Transaction>(t => 
            t.Date == Today && 
            t.Amount == NegativeAmount));
    }

    [Fact]
    public void PrintStatement()
    {
        _transactionRepository.All().Returns(Transactions);

        _accountService.PrintStatement();

        Received.InOrder(() =>
        {
            _console.PrintLine("DATE | AMOUNT | BALANCE");
            _console.PrintLine("10/04/2014 | 500.00 | 1400.00");
            _console.PrintLine("02/04/2014 | -100.00 | 900.00");
            _console.PrintLine("01/04/2014 | 1000.00 | 1000.00");
        });
    }
}