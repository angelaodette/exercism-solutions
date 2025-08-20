class RemoteControlCar
{    
    private int _meters;
    private int _battery = 100;
    
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_meters} meters";
    }

    public string BatteryDisplay()
    {
        if (_battery > 0)
        {
            return $"Battery at {_battery}%";
        }
        else 
        {
            return "Battery empty";
        }
    }

    public void Drive()
    {
        if (_battery > 0)
        {
            _meters += 20;
            _battery -= 1;
        }
    }
}
