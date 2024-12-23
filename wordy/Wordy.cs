using System;
using System.Collections.Generic;
using System.Linq;

using Xunit.Sdk;

public static class Wordy
{
    public static int Answer(string question)
    {
        var words = question.Trim('?').Split(" ").ToList();
        var equasion = new List<string>();
        int result = 0;

        if (!int.TryParse(words.Last(), out int r))
            throw new ArgumentException();

        foreach (var word in words)
        {
            if (int.TryParse(word, out int resul))
                equasion.Add(word);

            if (word == "plus" || word == "minus" || word == "multiplied" || word == "divided")
                equasion.Add(word);
        }

        if (equasion.Count == 0)
            throw new ArgumentException();

        if (int.TryParse(equasion[0], out int res))
        {
            if (equasion.Count == 1 && words[words.Count - 1] == res.ToString())
            {
                return res;
            }

            result = res;
        }
        else
        {
            throw new ArgumentException();
        }

        for (int i = 1; i < equasion.Count; i += 2)
        {
            if (equasion.Count % 2 == 0 || !int.TryParse(equasion[i + 1], out int r2))
                throw new ArgumentException();

            switch (equasion[i])
            {
                case "plus":
                    result += r2;
                    break;

                case "minus":
                    result -= r2;
                    break;

                case "multiplied":
                    result *= r2;
                    break;

                case "divided":
                    result /= r2;
                    break;

                default:
                    break;
            }
        }


        return result;

    }
}