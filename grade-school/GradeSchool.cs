using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class GradeSchool
{
    private IDictionary<int, List<string>> roster = new Dictionary<int, List<string>>();
    public bool Add(string student, int grade)
    {
        foreach (var item in Roster())
        {
            if (item == student)
                return false;
        }

        if (!roster.ContainsKey(grade))
            roster.Add(grade, new List<string> { student });

        else
        {
            roster[grade].Add(student);
        }

        return true;
    }

    public IEnumerable<string> Roster()
    {
        List<string> allStudents = new List<string>();
         var sortedByKey = roster.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        
        foreach (var item in sortedByKey)
        {
            List<string> x = item.Value;
            x.Sort();
            allStudents = allStudents.Concat(x).ToList();
        }

        return allStudents.ToArray();
    }

    public IEnumerable<string> Grade(int grade)
    {
         if (!roster.ContainsKey(grade))
            return [];

        var classroom = roster[grade];
        classroom.Sort();
        return classroom.ToArray();
    }
}