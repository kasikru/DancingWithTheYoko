using System;
using System.Collections.Generic;

using Microsoft.VisualBasic;

public class Robot
{
    static List<string> namesLedger = new List<string>();
    string name;
    Random rnd = new Random();

    public Robot()
    {
        Reset();
    }

    public string Name
    {
        get
        {
            return name;
        }
    }

    public void Reset()
    {
        do
        {
            int number1 = rnd.Next(0, 9);
            int number2 = rnd.Next(0, 9);
            int number3 = rnd.Next(0, 9);

            char let1 = (char)('A' + rnd.Next(0, 26));
            char let2 = (char)('A' + rnd.Next(0, 26));
            
            name = $"{let1}{let2}{number1}{number2}{number3}";
        } while (namesLedger.Contains(name));

        namesLedger.Add(name);
    }
}