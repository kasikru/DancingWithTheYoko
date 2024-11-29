using System;
using System.Linq;
using System.Collections.Generic;

public class Anagram
{
    private string baseWord;
    private List<string> resultMatches = new List<string>();

    public Anagram(string baseWord)
    {
       this.baseWord = baseWord; 
    }
    public string[] FindAnagrams(string[] potentialMatches)
    {
        foreach (var item in potentialMatches)
        {
            if(item.Length != baseWord.Length || item.ToLower() == baseWord.ToLower())
                continue;
            else
            {
                if(String.Concat(item.ToLower().OrderBy(c => c)) 
                    == String.Concat(baseWord.ToLower().OrderBy(c => c)))
                    resultMatches.Add(item);  
            }
        }
        return resultMatches.ToArray();
    }
} 