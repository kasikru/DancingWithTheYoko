using System;

public class SpaceAge
{
    private int seconds;    
    public SpaceAge(int seconds)
    {
        this.seconds = seconds;
    }

    public double Calculate(double orbitalPeriod)
    {
        int earthSeconds = 31557600;
        return Math.Round(seconds/Math.Round(earthSeconds*orbitalPeriod,2),2);
    }   

    public double OnEarth()
    {
        return Calculate(1.0);
    }

    public double OnMercury()
    {
        return Calculate(0.2408467);
    }

    public double OnVenus()
    {
        return Calculate(0.61519726);
    }

    public double OnMars()
    {
        return Calculate(1.8808158);
    }

    public double OnJupiter()
    {
        return Calculate(11.862615);
    }

    public double OnSaturn()
    {
        return Calculate(29.447498);
    }

    public double OnUranus()
    {
        return Calculate(84.016846);
    }

    public double OnNeptune()
    {
        return Calculate(164.79132);
    }
}