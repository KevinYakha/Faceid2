using System;
using System.Numerics;

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
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        return ((FacialFeatures)obj).EyeColor == EyeColor && ((FacialFeatures)obj).PhiltrumWidth == PhiltrumWidth;
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {
        // TODO: write your implementation of GetHashCode() here
        throw new NotImplementedException();
        return base.GetHashCode();
    }
    // TODO: implement GetHashCode() methods
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
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        return FacialFeatures.Equals(((Identity)obj).FacialFeatures) && Email == ((Identity)obj).Email;
    }
    // TODO: implement GetHashCode() methods
}

public class Authenticator
{
    private Identity[] identities;
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        return identity.Equals(new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m)));
    }

    public bool Register(Identity identity)
    {
        if (!IsRegistered(identity))
        {
            if (identities == null)
            {
                identities = [identity];
                return true;
            }
            Array.Resize(ref identities, identities.Length + 1);
            identities[identities.Length - 1] = identity;
            return true;
        }
        return false;
    }

    public bool IsRegistered(Identity identity)
    {
        if (identities == null)
            return false;
        for (int i = 0; i < identities.Length; i++)
        {
            if (identities[i].Equals(identity))
                return true;
        }
        return false;
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        throw new NotImplementedException("Please implement the Authenticator.AreSameObject() method");
    }
}
