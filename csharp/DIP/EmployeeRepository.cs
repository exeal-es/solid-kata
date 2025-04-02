namespace DIP;

public class EmployeeRepository
{
    public virtual IEnumerable<Employee> FindEmployeesBornOn(DateOnly date)
    {
        // This is just a sample implementation
        if (date.Month == 1 && date.Day == 1)
        {
            yield return new Employee("John", "Doe", new DateOnly(1990, 1, 1), "john.doe@example.com");
        }
    }
}