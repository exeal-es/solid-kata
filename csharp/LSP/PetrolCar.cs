namespace LSP;

public class PetrolCar : Vehicle
{
    private const int FuelTankFull = 100;
    private int _fuelTankLevel;

    public override void FillUpWithFuel()
    {
        _fuelTankLevel = FuelTankFull;
    }

    public override void ChargeBattery()
    {
        throw new NotSupportedException("A petrol car cannot be recharged");
    }

    public int FuelTankLevel()
    {
        return _fuelTankLevel;
    }
}