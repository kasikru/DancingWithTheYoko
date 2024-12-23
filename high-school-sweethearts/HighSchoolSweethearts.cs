using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        char heart = '♡';
        return $"{studentA,29} {heart} {studentB,-29}";
    }

    public static string DisplayBanner(string stuA, string stuB) =>
   $@"
         ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {stuA.Trim()}  +  {stuB.Trim()}     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
    ";

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours) =>
        string.Format(new CultureInfo("de-DE"), "{0} and {1} have been dating since {2:d} - that's {3:n2} hours", studentA, studentB, start, hours);
}
