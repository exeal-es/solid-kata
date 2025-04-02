namespace OCP.Tests;

public class EmployeeShould
{
    private const int Bonus = 100;
    private const int Salary = 1000;

    [Fact]
    public void NotAddBonusToTheEngineerPayAmount()
    {
        var employee = new Employee(Salary, Bonus, EmployeeType.Engineer);
        Assert.Equal(Salary, employee.PayAmount());
    }

    [Fact]
    public void AddBonusToTheManagerPayAmount()
    {
        var employee = new Employee(Salary, Bonus, EmployeeType.Manager);
        Assert.Equal(Salary + Bonus, employee.PayAmount());
    }
}