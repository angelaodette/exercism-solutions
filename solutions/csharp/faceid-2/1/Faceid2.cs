public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object obj) => this.Equals(obj as FacialFeatures);

    public bool Equals(FacialFeatures f)
    {
        if (f is null)
        {
            return false;
        }
        if (Object.ReferenceEquals(this, f))
        {
            return true;
        }
        if (this.GetType() != f.GetType())
        {
            return false;
        }
        return (EyeColor == f.EyeColor) && (PhiltrumWidth == f.PhiltrumWidth);
    }
    
    public override int GetHashCode() => (EyeColor, PhiltrumWidth).GetHashCode();
    
    public static bool operator ==(FacialFeatures fa, FacialFeatures fb)
    {
        if (fa is null)
        {
            if (fb is null)
            {
                return true;
            }
            return false;
        }
        return fa.Equals(fb);
    }

    public static bool operator !=(FacialFeatures fa, FacialFeatures fb) => !(fa == fb);
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    
    public override bool Equals(object obj) => this.Equals(obj as Identity);

    public bool Equals(Identity i)
    {
        if (i is null)
        {
            return false;
        }
        if (Object.ReferenceEquals(this, i))
        {
            return true;
        }
        if (this.GetType() != i.GetType())
        {
            return false;
        }
        return (Email == i.Email) && (FacialFeatures == i.FacialFeatures);
    }
    
    public override int GetHashCode() => (Email, FacialFeatures).GetHashCode();
    
    public static bool operator ==(Identity ia, Identity ib)
    {
        if (ia is null)
        {
            if (ib is null)
            {
                return true;
            }
            return false;
        }
        return ia.Equals(ib);
    }

    public static bool operator !=(Identity ia, Identity ib) => !(ia == ib);
}

public class Authenticator
{
    HashSet<Identity> identities = new HashSet<Identity>();

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);        
    }

    public bool IsAdmin(Identity identity)
    {
        Identity admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
        return identity.Equals(admin);
    }

    public bool Register(Identity identity)
    {
        if (!IsRegistered(identity))
        {
            identities.Add(identity);
            return true;
        }
        return false;
    }

    public bool IsRegistered(Identity identity)
    {
        if (identities.Contains(identity))
        {
            return true;
        }
        return false;
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return System.Object.ReferenceEquals(identityA, identityB);
    }
}
