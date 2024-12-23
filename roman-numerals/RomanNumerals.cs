using System;
using System.Linq;
using System.Text;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int value)
    {
        StringBuilder number = new StringBuilder();

        (int number, string numeral)[] romanNumerals = new (int, string)[]
       {(1000, "M"), (900, "CM"),(500,"D"),(400,"CD"),(100,"C"),(90,"XC"),
        (50,"L"),(40, "XL"),(10,"X"),(9,"IX"),(5,"V"),(4,"IV"),(1,"I")};

        foreach (var (item, numeral) in romanNumerals)
        {
            while (value >= item)
            {
                number.Append(numeral);
                value -= item;
            }
        }
        return number.ToString();
    }
}