using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

public class LogParser
{
    string[] logs = new string[]
    {
        "[TRC]",
        "[DBG]",
        "[INF]",
        "[WRN]",
        "[ERR]",
        "[FTL]"
    };



    public bool IsValidLine(string text) =>
    Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");


    public string[] SplitLogLine(string text) =>
    Regex.Split(text, @"<[\^*=-]+>");

    public int CountQuotedPasswords(string lines) =>
    Regex.Matches(lines.ToLower(), @""".*password.*""").Count();

    public string RemoveEndOfLineText(string line) =>
    Regex.Replace(line, @"end-of-line\d+", "");


    public string[] ListLinesWithPasswords(string[] lines)
    {
        var newLines = new List<string>();

        foreach (var item in lines)
        {
            var match = Regex.Match(item, @"password\w+", RegexOptions.IgnoreCase);

            if (match == Match.Empty)
                newLines.Add($"--------: {item}");
            else
                newLines.Add($"{match.Value}: {item}");
        }

        return newLines.ToArray();

    }
}
