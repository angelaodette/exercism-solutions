public class Player
{
    Random rnd = new();

    public int RollDie() => rnd.Next(1, 19);
    
    public double GenerateSpellStrength() => rnd.Next(10000)*.01;
}
