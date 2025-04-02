namespace DIP;

public class BirthdayGreeter
{
    private readonly EmployeeRepository _employeeRepository;
    private readonly Clock _clock;

    public BirthdayGreeter(EmployeeRepository employeeRepository, Clock clock)
    {
        _employeeRepository = employeeRepository;
        _clock = clock;
    }

    public void SendGreetings()
    {
        var today = _clock.Today();
        var birthdayEmployees = _employeeRepository.FindEmployeesBornOn(today);

        foreach (var employee in birthdayEmployees)
        {
            var email = EmailFor(employee);
            new EmailSender().Send(email);
        }
    }

    private static Email EmailFor(Employee employee)
    {
        var message = $"Happy birthday, dear {employee.FirstName}!";
        return new Email(employee.Email, "Happy birthday!", message);
    }
}