static class AssemblyLine
{
    const int CarsPerHour = 221;

    public static double SuccessRate(int speed)
    {
        double successRate = 0;
        
        switch (speed)
        {
            case 0:
                successRate = 0;
                break;
            case < 5:
                successRate = 1;
                break;
            case < 9:
                successRate = .9;
                break;
            case 9:
                successRate = .8;
                break;
            case 10:
                successRate = .77;
                break;
        }
        return successRate;
    }
    
    public static double ProductionRatePerHour(int speed) => speed * CarsPerHour * SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed) => (int) ProductionRatePerHour(speed) / 60;
}
