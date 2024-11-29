using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public static class PythagoreanTriplet
{
    private static Tuple<(int x, int y, int z)>[] pitagorean;
    private static int a = 1;
    private static int b = 2;

    public static Tuple<(int a, int b, int c)>[] TripletsWithSum(int sum)
    {
        double c = Math.Sqrt(sum);

        if(!(c%1==0))
        {
            return pitagorean;
        }

        while(a*a <= sum - b*b)
        {
            while(b > a && b*b <= sum - a*a)
            {
                if(a*a + b*b == sum)
                {
                    int d = System.Convert.ToInt32(System.Math.Floor(c));
                    pitagorean[0] = ;
                }
                b++;
            }
            a++;
            b = 1;
        }

        return pitagorean;
    }
}