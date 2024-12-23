using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public enum Plant
{
    Violets = 'V',
    Radishes = 'R',
    Clover = 'C',
    Grass = 'G'
}


public class KindergartenGarden
{
    private string diagram;
    private List<string> diag;

    public IDictionary<string, int> children = new Dictionary<string, int>
{
    { "Alice", 1},
    { "Bob", 3},
    { "Charlie", 5},
    { "David", 7},
    { "Eve", 9},
    { "Fred", 11},
    { "Ginny", 13},
    { "Harriet", 15},
    { "Ileana", 17},
    { "Joseph", 19},
    { "Kincaid", 21},
    { "Larry", 23}
};

    public KindergartenGarden(string diagram)
    {
        this.diagram = diagram;
        this.diag = diagram.Split('\n').ToList();
    }


    public IEnumerable<Plant> Plants(string student)
    {
        List<Plant> studentsPlants = new List<Plant>();

        int plantLocation = children[student] - 1;

        foreach (var item in diag)
        {
            for (int i = plantLocation; i <= plantLocation + 1; i++)
            {
                if (item[i] == 'V')
                    studentsPlants.Add(Plant.Violets);
                if (item[i] == 'R')
                    studentsPlants.Add(Plant.Radishes);
                if (item[i] == 'C')
                    studentsPlants.Add(Plant.Clover);
                if (item[i] == 'G')
                    studentsPlants.Add(Plant.Grass);
            }
        }

        return studentsPlants;

    }
}