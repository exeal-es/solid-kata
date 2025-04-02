using NSubstitute;

namespace DIP.Tests;

public class BirthdayGreeterShould
{
    private const int CurrentMonth = 7;
    private const int CurrentDayOfMonth = 9;
    private static readonly DateTime Today = new(2024, CurrentMonth, CurrentDayOfMonth);

    private readonly EmployeeRepository _employeeRepository;
    private readonly Clock _clock;
    private readonly BirthdayGreeter _birthdayGreeter;
    private readonly StringWriter _consoleOutput;

    public BirthdayGreeterShould()
    {
        _employeeRepository = Substitute.For<EmployeeRepository>();
        _clock = Substitute.For<Clock>();
        _birthdayGreeter = new BirthdayGreeter(_employeeRepository, _clock);
        _consoleOutput = new StringWriter();
        System.Console.SetOut(_consoleOutput);
    }

    [Fact]
    public void SendGreetingEmailToEmployee()
    {
        _clock.Today().Returns(DateOnly.FromDateTime(Today));
        var employee = new Employee("John", "Doe", DateOnly.FromDateTime(new DateTime(1990, CurrentMonth, CurrentDayOfMonth)), "john.doe@foobar.com");
        _employeeRepository.FindEmployeesBornOn(DateOnly.FromDateTime(Today)).Returns(new List<Employee> { employee });

        _birthdayGreeter.SendGreetings();

        var expected = $"To: {employee.Email}, Subject: Happy birthday!, Message: Happy birthday, dear {employee.FirstName}!" + Environment.NewLine;
        Assert.Equal(expected, _consoleOutput.ToString());
    }
}