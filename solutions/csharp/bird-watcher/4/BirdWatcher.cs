class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => new int[] {0, 2, 5, 3, 7, 8, 4};

    public int Today() => birdsPerDay[birdsPerDay.Length - 1];

    public void IncrementTodaysCount() => birdsPerDay[birdsPerDay.Length - 1]++;

    public bool HasDayWithoutBirds()
    {
        foreach (int count in birdsPerDay)
        {
            if (count == 0)
            {
                return true;
            }
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int birdCount = 0;
        for (int i = 0; i < numberOfDays; i++)
        {
            birdCount += birdsPerDay[i];
        }
        return birdCount;
    }

    public int BusyDays()
    {
        int busyCount = 0;
        foreach (int count in birdsPerDay)
        {
            if (count >= 5)
            {
                busyCount++;
            }
        }
        return busyCount;
    }
}
