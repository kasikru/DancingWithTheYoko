using System;
using System.Linq;

public static class Luhn
{
    public static bool IsValid(string number)
    {
        number = number.Replace(" ", "");
        int sum = 0;

        if (number.Count() < 2)
            return false;

        for (int i = number.Count()-2; i >= 0; i-=2)
        {
            if(int.TryParse(number[i].ToString(), out int result))
            {
                result = result*2;

                if(result>9)
                    result -= 9;

                sum += result;
            }
            else
            {
                return false;
            }
        }

        for (int i = number.Count()-1; i >= 0; i-=2)
        {
            if(int.TryParse(number[i].ToString(), out int result))
            {
                sum += result;
            }
            else
            {
                return false;
            }
        }

        return sum%10 == 0;
    }
}