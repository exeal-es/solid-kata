namespace ISP;

public class Dog : IAnimal
{
    public void Fly() { }

    public void Run()
    {
        Console.WriteLine("Dog is running");
    }

    public void Bark()
    {
        Console.WriteLine("Dog is barking");
    }
}