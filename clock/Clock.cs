using System;


using Microsoft.Win32.SafeHandles;

public class Clock
{
    private int hours;
    private int minutes;

    public Clock(int hours, int minutes)
    {
        this.minutes = hours * 60 + minutes;
        this.hours = this.minutes / 60 % 24;
        this.minutes %= 60; 

        
        if (this.minutes < 0)
        {
            this.hours--;
            this.minutes += 60;
        }
        if (this.hours < 0)
        {
            this.hours += 24;
        }
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(hours, minutes + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(hours, minutes - minutesToSubtract);
    }

    public override string ToString()
    {
        return string.Format("{0:00}:{1:00}",hours, minutes);
    }

    public override bool Equals(System.Object obj)
    {
        if(obj == null || !(obj is Clock))
            return false;
        else
            return Equals((Clock)obj);      
    }

    public bool Equals(Clock clock)
    {
        return clock.ToString() == ToString();
    }

    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }
}
