using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object obj)
    {
        if (obj is FacialFeatures other)
        {
            return EyeColor == other.EyeColor &&
                   PhiltrumWidth == other.PhiltrumWidth;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
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
    protected bool Equals(Identity other)
    {
        return Email == other.Email && Equals(FacialFeatures, other.FacialFeatures);
    }

     public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Identity)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    private Identity admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    private HashSet<Identity> identities = new HashSet<Identity>();

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        if (faceA.GetHashCode() == faceB.GetHashCode())
            return true;

        return false;
    }

    public bool IsAdmin(Identity identity)
    {
        if (admin.GetHashCode() == identity.GetHashCode())
            return true;
        return false;
    }

    public bool Register(Identity identity)
    {
       return identities.Add(identity);
    }

    public bool IsRegistered(Identity identity)
    {
        return identities.Contains(identity);
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return ReferenceEquals(identityA,identityB);
    }
}
