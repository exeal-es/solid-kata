namespace OCP;

public class Employee
{
    private readonly int _salary;
    private readonly int _bonus;
    private readonly EmployeeType _type;

    public Employee(int salary, int bonus, EmployeeType type)
    {
        _salary = salary;
        _bonus = bonus;
        _type = type;
    }

    public int PayAmount()
    {
        switch (_type)
        {
            case EmployeeType.Engineer:
                return _salary;
            case EmployeeType.Manager:
                return _salary + _bonus;
            default:
                return 0;
        }
    }
}