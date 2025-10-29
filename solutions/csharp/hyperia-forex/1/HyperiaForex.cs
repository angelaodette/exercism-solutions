public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    // Equality operators
    public static bool operator ==(CurrencyAmount left, CurrencyAmount right) 
    {
        if (left.currency != right.currency)
        {
            throw new ArgumentException();
        }
        return left.amount == right.amount;
    }

    public static bool operator !=(CurrencyAmount left, CurrencyAmount right) 
    {
        if (left.currency != right.currency)
        {
            throw new ArgumentException();
        }
        return left.amount != right.amount;
    }

    // Comparison operators

    public static bool operator <(CurrencyAmount left, CurrencyAmount right) 
    {
        if (left.currency != right.currency)
        {
            throw new ArgumentException();
        }
        return left.amount < right.amount;
    }

    public static bool operator >(CurrencyAmount left, CurrencyAmount right) 
    {
        if (left.currency != right.currency)
        {
            throw new ArgumentException();
        }
        return left.amount > right.amount;
    }
    
    // Arithmetic operators
    public static CurrencyAmount operator +(CurrencyAmount left, CurrencyAmount right) 
    {
        if (left.currency != right.currency)
        {
            throw new ArgumentException();
        }
        return new CurrencyAmount(left.amount + right.amount, left.currency);
    }
        public static CurrencyAmount operator -(CurrencyAmount left, CurrencyAmount right) 
    {
        if (left.currency != right.currency)
        {
            throw new ArgumentException();
        }
        return new CurrencyAmount(left.amount - right.amount, left.currency);
    }
        public static CurrencyAmount operator *(CurrencyAmount ca, decimal multiplier) => new CurrencyAmount(ca.amount * multiplier, ca.currency);
        public static CurrencyAmount operator *(decimal multiplier, CurrencyAmount ca) => new CurrencyAmount(ca.amount * multiplier, ca.currency);
        public static CurrencyAmount operator /(CurrencyAmount ca, decimal divisor) => new CurrencyAmount(ca.amount / divisor, ca.currency);
    
    // Type conversion operators
    public static implicit operator double(CurrencyAmount ca) => (double) ca.amount;
    public static implicit operator decimal(CurrencyAmount ca) => (decimal) ca.amount;
}
