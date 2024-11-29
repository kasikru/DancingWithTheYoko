using System;
using System.Collections.Generic;
using System.Linq;

public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary() 
        => new Dictionary<int, string>();
    

    public static Dictionary<int, string> GetExistingDictionary()
    {
       var numbers = new Dictionary<int, string>()
       {
        [1] = "United States of America",
        [55] = "Brazil",
        [91] = "India"
       };

       return numbers;
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        var numbers = GetEmptyDictionary();
        numbers.Add(countryCode, countryName);

        return numbers;
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode, countryName);
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if(!existingDictionary.ContainsKey(countryCode))
            return string.Empty;

        existingDictionary.TryGetValue(countryCode, out string countryName);
        return countryName;
    }



    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode) 
        => existingDictionary.ContainsKey(countryCode);

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if(!CheckCodeExists(existingDictionary,countryCode))
            return existingDictionary;
        
        existingDictionary[countryCode] = countryName;
        return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        string countryCode = string.Empty;

        foreach (var value in existingDictionary.Values)
        {
            if (value.Count() > countryCode.Count())
            {
                countryCode = value;
            }
        }

        return countryCode;
    }
}