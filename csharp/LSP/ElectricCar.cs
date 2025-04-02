namespace LSP;

public class ElectricCar : Vehicle
{
    private const int BatteryFull = 100;
    private int _batteryLevel;

    public override void FillUpWithFuel()
    {
        throw new NotSupportedException("It's an electric car");
    }

    public override void ChargeBattery()
    {
        _batteryLevel = BatteryFull;
    }

    public int BatteryLevel()
    {
        return _batteryLevel;
    }
}