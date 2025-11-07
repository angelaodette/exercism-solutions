class WeighingMachine
{
    private int _precision;
    private double _weight;
    private double _tareAdjustment = 5;

    public WeighingMachine(int precision)
    {
        _precision = precision;
    }

    public int Precision
    {
        get => _precision;
        set => _precision = value;
    }
    
    public double Weight
    {
        get => _weight;
        set { 
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _weight = value;
            }
    }

    public double TareAdjustment
    {
        get => _tareAdjustment;
        set => _tareAdjustment = value;
    }

    public string DisplayWeight
    {
        get => $"{(_weight - TareAdjustment).ToString($"F{_precision}")} kg";
    }
}
