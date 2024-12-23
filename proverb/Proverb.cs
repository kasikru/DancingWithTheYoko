using System;
using System.Collections.Generic;
using System.Linq;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        List<string> rhyme = new List<string>();

        if (subjects.Count() == 1)
            rhyme.Add($"And all for the want of a {subjects[0]}.");
        else if (subjects.Count() > 1)
        {
            for (int i = 0; i < subjects.Count() - 1; i++)
            {
                rhyme.Add($"For want of a {subjects[i]} the {subjects[i + 1]} was lost.");
            }

            rhyme.Add($"And all for the want of a {subjects[0]}.");
        }

        return rhyme.ToArray();
    }
}