class WeighingMachine
{
    private int precision;
    public int Precision
    {
        get { return precision; }
        set { precision = value; }
    }
    
    private double weight;
    public double Weight
    {
        get { return weight; }
        set { 
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                weight = value;
            }
    }

    public string DisplayWeight
    {
        get { return $"{(weight - TareAdjustment).ToString($"F{precision}")} kg";}
    }

    public double TareAdjustment { get; set; } = 5;

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}
