using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        var wordDict = new Dictionary<string, int>();
        var listOfWords = new List<string>();



        listOfWords = Cleanup(phrase.ToLower().Split(' ', ':', '.', ',', ';', '!', '?', '\n').ToList());


        foreach (var item in listOfWords)
        {
            if (!wordDict.Keys.Contains(item) && item != "")
                wordDict.Add(item, listOfWords.Where(x => x.Equals(item)).Count());
        }

        return wordDict;
    }

    public static List<string> Cleanup(List<string> input)
    {
        var listOfWords = new List<string>();

        foreach (var item in input)
        {
            var tmp = Regex.Replace(item, "[^0-9a-zA-Z']+", "");

            if (tmp != "")
            {
                if (!char.IsLetterOrDigit(tmp[0]))
                {
                    tmp = tmp.Remove(0, 1);
                }

                if (tmp != "" && !char.IsLetterOrDigit(tmp.Last()))
                {
                    tmp = tmp.Remove(tmp.Count() - 1, 1);
                }


                listOfWords.Add(tmp);
            }

        }

        return listOfWords;
    }
}