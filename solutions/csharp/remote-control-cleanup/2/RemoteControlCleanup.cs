public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }

    private Speed currentSpeed;

    public RemoteControlCar()
    {
        Telemetry = new Telemetry(this);
    }

    public Telemetry Telemetry { get; }

    public string GetSpeed() => currentSpeed.ToString();

    internal void SetSponsor(string sponsorName) => CurrentSponsor = sponsorName;

    internal void SetSpeed(Speed speed) => currentSpeed = speed;
}

public class Telemetry
{
    private readonly RemoteControlCar _car;

    public Telemetry(RemoteControlCar car)
    {
        _car = car;
    }

    public void Calibrate()
    {
    }

    public bool SelfTest() => true;

    public void ShowSponsor(string sponsorName)
    {
        _car.SetSponsor(sponsorName);
    }

    public void SetSpeed(decimal amount, string unitsString)
    {
        var units = unitsString == "cps"
            ? SpeedUnits.CentimetersPerSecond
            : SpeedUnits.MetersPerSecond;

        _car.SetSpeed(new Speed(amount, units));
    }
}

public enum SpeedUnits
{
    MetersPerSecond,
    CentimetersPerSecond
}

public struct Speed
{
    public decimal Amount { get; }
    public SpeedUnits SpeedUnits { get; }

    public Speed(decimal amount, SpeedUnits speedUnits)
    {
        Amount = amount;
        SpeedUnits = speedUnits;
    }

    public override string ToString()
    {
        string unitsString = "meters per second";
        if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
        {
            unitsString = "centimeters per second";
        }

        return $"{Amount} {unitsString}";
    }
}
