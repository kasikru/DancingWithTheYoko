using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }


    public static bool operator ==(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency == b.currency)
        {
            if (a.amount == b.amount)
                return true;
        }
        else
            throw new ArgumentException();

        return false;
    }

    public static bool operator !=(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency == b.currency)
        {
            if (a.amount != b.amount)
                return true;
        }
        else
            throw new ArgumentException();

        return false;
    }

    public static bool operator <(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency == b.currency)
        {
            if (a.amount < b.amount)
                return true;
        }
        else
            throw new ArgumentException();

        return false;
    }

    public static bool operator >(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency == b.currency)
        {
            if (a.amount > b.amount)
                return true;
        }
        else
            throw new ArgumentException();

        return false;
    }

    public static CurrencyAmount operator +(CurrencyAmount a, CurrencyAmount b) =>
    (a.currency == b.currency) ? new CurrencyAmount(a.amount + b.amount, a.currency) :
    throw new ArgumentException();

    public static CurrencyAmount operator -(CurrencyAmount a, CurrencyAmount b) =>
    (a.currency == b.currency) ? new CurrencyAmount(a.amount - b.amount, a.currency) :
    throw new ArgumentException();

    public static CurrencyAmount operator *(CurrencyAmount a, CurrencyAmount b) =>
   (a.currency == b.currency) ? new CurrencyAmount(a.amount * b.amount, a.currency) :
   throw new ArgumentException();

    public static CurrencyAmount operator /(CurrencyAmount a, CurrencyAmount b) =>
   (a.currency == b.currency) ? new CurrencyAmount(a.amount / b.amount, a.currency) :
   throw new ArgumentException();

    public static explicit operator double(CurrencyAmount a)
    {
        return (double)a.amount;
    }
    public static implicit operator decimal(CurrencyAmount a)
    {
        return a.amount;
    }

    public override int GetHashCode()
    {
        return currency.GetHashCode() * amount.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        return GetHashCode() == obj.GetHashCode();
    }



    // TODO: implement arithmetic operators

    // TODO: implement type conversion operators
}
