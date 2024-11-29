using System;

public static class EliudsEggs
{
    public static int power(int number)
    {
        int n = 0;

        while (number > Math.Pow(2, n))
        {
            n++;
        }

        return n-1;
    }

    public static int EggCount(int encodedCount)
    {
        int coop = 0;
        long newEncodedCount = encodedCount;

        for (int i = power(encodedCount); i >= 0; i--)
        {
            int powerOf = Convert.ToInt32(Math.Pow(2, i));

            if (powerOf <= newEncodedCount)
            {
                coop++;
                newEncodedCount = newEncodedCount - powerOf;
            }
        }

        return coop;
    }
}
