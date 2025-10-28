public class Authenticator
{
    public Identity Admin 
    { get 
        {
            return new Identity
            {
                Email = "admin@ex.ism",
                FacialFeatures = new FacialFeatures { EyeColor = "green", PhiltrumWidth = 0.9m },
                NameAndAddress = new List<string> { "Chanakya", "Mumbai", "India" }
            };
        }
    }

    Identity bertrand = new Identity
    {
        Email = "bert@ex.ism",
        FacialFeatures = new FacialFeatures { EyeColor = "blue", PhiltrumWidth = 0.8m},
        NameAndAddress = new List<string> {"Bertrand", "Paris", "France"}            
        };

    Identity anders = new Identity
    {
        Email = "anders@ex.ism",
        FacialFeatures = new FacialFeatures { EyeColor = "brown", PhiltrumWidth = 0.85m},
        NameAndAddress = new List<string> {"Anders", "Redmond", "USA"}            
        };
    
    public IDictionary<string, Identity> Developers 
        { 
        get
            {
                return new Dictionary<string, Identity>
                {
                    {"Bertrand", bertrand},
                    {"Anders", anders}
                };
            }
        }
}

//**** please do not modify the FacialFeatures class ****
public class FacialFeatures
{
    public required string EyeColor { get; set; }
    public required decimal PhiltrumWidth { get; set; }
}

//**** please do not modify the Identity class ****
public class Identity
{
    public required string Email { get; set; }
    public required FacialFeatures FacialFeatures { get; set; }
    public required IList<string> NameAndAddress { get; set; }
}
