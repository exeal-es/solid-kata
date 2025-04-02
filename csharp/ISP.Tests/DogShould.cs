namespace ISP.Tests;

public class DogShould
{
    private readonly Dog _dog = new();

    [Fact]
    public void Run()
    {
        var output = new StringWriter();
        Console.SetOut(output);
        _dog.Run();
        Assert.Equal("Dog is running" + Environment.NewLine, output.ToString());
    }

    [Fact]
    public void Bark()
    {
        var output = new StringWriter();
        Console.SetOut(output);
        _dog.Bark();
        Assert.Equal("Dog is barking" + Environment.NewLine, output.ToString());
    }
}