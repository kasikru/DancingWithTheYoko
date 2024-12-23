using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            long output = checked(@base * multiplier);
            return output.ToString();
        }
        catch (Exception)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
            float output = checked(@base * multiplier);

            if(output > float.MaxValue)
                 return "*** Too Big ***";
            
            return output.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
                try
        {
            var output = checked(salaryBase*multiplier); 
            return output.ToString();       
        }
        catch (Exception)
        {
            return "*** Much Too Big ***";
        }
    }
}
