namespace LSP;

public abstract class Vehicle
{
    private bool _engineStarted;

    public void StartEngine()
    {
        _engineStarted = true;
    }

    public bool EngineIsStarted()
    {
        return _engineStarted;
    }

    public void StopEngine()
    {
        _engineStarted = false;
    }

    public abstract void FillUpWithFuel();
    public abstract void ChargeBattery();
}