class RemoteControlCar
{
    public int speed;
    public int batteryDrain;
    private int distance;
    public int fullBattery = 100;

    public RemoteControlCar(int carSpeed, int carBatteryDrain)
    {
        speed = carSpeed;
        batteryDrain = carBatteryDrain;        
    }
    
    public bool BatteryDrained()
    {
        return fullBattery < batteryDrain;
    }

    public int DistanceDriven()
    {
        return distance;
    }

    public void Drive()
    {
        if (fullBattery >= batteryDrain)
        {
            distance += speed;
            fullBattery -= batteryDrain;   
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    private int distance;

    public RaceTrack(int trackDistance)
    {
        distance = trackDistance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (car.DistanceDriven() <= distance && !car.BatteryDrained())
        {
            car.Drive();
        }        
        return car.DistanceDriven() >= distance;
    }
}
