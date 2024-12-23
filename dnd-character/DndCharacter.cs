using System;
using System.Collections.Generic;
using System.Linq;

public class DndCharacter
{
    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
    public int Hitpoints { get; }

        public DndCharacter(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
    {
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
        Hitpoints = 10 + Modifier(constitution);
    }



    public static int Modifier(int score)
    {
        return (int)Math.Floor((score - 10) * 0.5);
    }

    public static int Ability()
    {
        Random random = new Random();
        List<int> diceRolls = new List<int>();
        int sum = 0;

        for (int i = 0; i < 4; i++)
        {
            diceRolls.Add(random.Next(1, 7));
        }

        diceRolls.Sort();
        diceRolls.Remove(diceRolls[0]);

        foreach (var item in diceRolls)
        {
            sum += item;
        }

        return sum;
    }

    public static DndCharacter Generate()
    {
        return new DndCharacter(Ability(), Ability(), Ability(), Ability(), Ability(), Ability());
    }
         
}
