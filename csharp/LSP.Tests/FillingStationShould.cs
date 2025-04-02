namespace LSP.Tests;

public class FillingStationShould
{
    private const int Full = 100;
    private readonly FillingStation _fillingStation = new();

    [Fact]
    public void RefuelAPetrolCar()
    {
        var car = new PetrolCar();
        _fillingStation.Refuel(car);
        Assert.Equal(Full, car.FuelTankLevel());
    }

    [Fact]
    public void NotFailRefuelingAnElectricCar()
    {
        var car = new ElectricCar();
        var exception = Record.Exception(() => _fillingStation.Refuel(car));
        Assert.Null(exception);
    }

    [Fact]
    public void RechargeAnElectricCar()
    {
        var car = new ElectricCar();
        _fillingStation.Charge(car);
        Assert.Equal(Full, car.BatteryLevel());
    }

    [Fact]
    public void NotFailRechargingAPetrolCar()
    {
        var car = new PetrolCar();
        var exception = Record.Exception(() => _fillingStation.Charge(car));
        Assert.Null(exception);
    }
}