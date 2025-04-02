namespace LSP.Tests;

public class VehicleShould
{
    [Fact]
    public void StartEngine()
    {
        var vehicle = new TestableVehicle();
        vehicle.StartEngine();
        Assert.True(vehicle.EngineIsStarted());
    }

    [Fact]
    public void StopEngine()
    {
        var vehicle = new TestableVehicle();
        vehicle.StartEngine();
        vehicle.StopEngine();
        Assert.False(vehicle.EngineIsStarted());
    }

    private class TestableVehicle : Vehicle
    {
        public override void FillUpWithFuel()
        {
        }

        public override void ChargeBattery()
        {
        }
    }
}