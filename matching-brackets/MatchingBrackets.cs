using System;
using System.Text.RegularExpressions;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        
           
        string cleaned = Regex.Replace(input, @"[0-9a-zA-Z\s,.^&$+*%/-]", "");
        cleaned = cleaned.Replace(@"\","");

        while (cleaned != string.Empty)
        {
            if (!(cleaned.Contains("{}") || cleaned.Contains("[]") || cleaned.Contains("()")))
                return false;

            cleaned = cleaned.Replace("{}", string.Empty);
            cleaned = cleaned.Replace("()", string.Empty);
            cleaned = cleaned.Replace("[]", string.Empty);
        }

        return true;
    }
}
