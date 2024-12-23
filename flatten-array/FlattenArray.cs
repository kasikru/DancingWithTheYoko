using System;
using System.Collections;
using System.Collections.Generic;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        var flattenList = new List<int>();

        foreach (var item in input)
        {
            if (item == null)
            {
                continue;
            }
            else if (item is int)
            {
                flattenList.Add((int)item);
            }
            else
            {
                var add = Flatten((Array)item);
                
                foreach (var it in add)
                {
                    flattenList.Add((int)it);
                }
            }
        }
        return flattenList.ToArray();
    }
}