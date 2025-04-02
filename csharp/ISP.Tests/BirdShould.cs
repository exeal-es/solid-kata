namespace ISP.Tests;

public class BirdShould
{
    private readonly Bird _bird = new();

    [Fact]
    public void Run()
    {
        var output = new StringWriter();
        Console.SetOut(output);
        _bird.Run();
        Assert.Equal("Bird is running" + Environment.NewLine, output.ToString());
    }

    [Fact]
    public void Fly()
    {
        var output = new StringWriter();
        Console.SetOut(output);
        _bird.Fly();
        Assert.Equal("Bird is flying" + Environment.NewLine, output.ToString());
    }
}