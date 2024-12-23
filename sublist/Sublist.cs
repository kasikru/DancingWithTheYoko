using System;
using System.Collections.Generic;
using System.Linq;

public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static bool IsSublist<T>(List<T> mainList, List<T> subList)
    {
        for (int i = 0; i <= mainList.Count - subList.Count; i++)
        {
            if (mainList.Count == 0 || mainList.GetRange(i, subList.Count).SequenceEqual(subList))
            {
                return true;
            }
        }
        return false;
    }
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        if (list1.Count > list2.Count)
        {
            if (IsSublist(list1, list2))
                return SublistType.Superlist;
        }

        if (list1.Count < list2.Count)
        {
            if (IsSublist(list2, list1))
                return SublistType.Sublist;
        }

        if (list1.SequenceEqual(list2))
            return SublistType.Equal;
        else
            return SublistType.Unequal;

    }
}