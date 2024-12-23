using System;
using System.Collections;
using System.Collections.Generic;


public static class ResistorColorTrio
{
    public static Dictionary<string, int> bands = new Dictionary<string, int>
{
    {"black", 0},
    {"brown", 1},
    {"red", 2},
    {"orange",3},
    {"yellow",4},
    {"green",5},
    {"blue",6},
    {"violet",7},
    {"grey",8},
    {"white",9},
};
    public static string Label(string[] colors)
    {
        long ohms = 0;

        ohms = bands[colors[0]] * 10 + bands[colors[1]];

        for (int i = 0; i < bands[colors[2]]; i++)
        {
            ohms *= 10;
        }

        if (ohms % 1000 == 0)
            return $"{ohms / 1000} kiloohms";
        else
            return $"{ohms} ohms";
    }
}
