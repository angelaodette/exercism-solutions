public interface IRemoteControlCar
{   
    int DistanceTravelled { get; }
    void Drive();
}

public class ProductionRemoteControlCar: IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(ProductionRemoteControlCar otherCar)
    {
        if (otherCar == null) return 1;

        return NumberOfVictories.CompareTo(otherCar.NumberOfVictories);
    }
}

public class ExperimentalRemoteControlCar: IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        List<ProductionRemoteControlCar> rankedList = new List<ProductionRemoteControlCar>();

        if (prc1.CompareTo(prc2) == 0)
        {
            rankedList.Add(prc1);
            rankedList.Add(prc2);
        }
        else
        {
            rankedList.Add(prc2);
            rankedList.Add(prc1);
        }
        return rankedList;
    }
}
