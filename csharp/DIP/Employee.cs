namespace DIP;

public class Employee
{
    public string FirstName { get; }
    public string LastName { get; }
    public DateOnly DateOfBirth { get; }
    public string Email { get; }

    public Employee(string firstName, string lastName, DateOnly dateOfBirth, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Email = email;
    }
}