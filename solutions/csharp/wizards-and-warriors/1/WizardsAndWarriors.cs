abstract class Character
{
    protected string CharacterType {get; set;}
        
    protected Character(string characterType)
    {
        CharacterType = characterType;
    }
    
    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() => $"Character is a {CharacterType}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {}

    public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;
}

class Wizard : Character
{
    public bool hasSpell = false;
    
    public Wizard() : base("Wizard")
    {}

    public override int DamagePoints(Character target) => hasSpell ? 12 : 3;

    public void PrepareSpell()
    {
        hasSpell = true;
    }

    public override bool Vulnerable() => hasSpell ? false : true;    
}
