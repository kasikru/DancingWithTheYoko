using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualBasic;

public class HighScores
{
    public static List<int> highScores;
    public HighScores(List<int> list) => highScores = list;

    public List<int> Scores() => highScores;

    public int Latest() => highScores.Last();

    public int PersonalBest() => highScores.Max();

    public List<int> PersonalTopThree() => highScores.OrderByDescending(i => i).Take(3).ToList();
}