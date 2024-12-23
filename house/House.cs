using System;
using System.Text;

public static class House
{
    static string[] whom = new string[]
    {
        "the house that Jack built.",
        "the malt",
        "the rat",
        "the cat",
        "the dog",
        "the cow with the crumpled horn",
        "the maiden all forlorn",
        "the man all tattered and torn",
        "the priest all shaven and shorn",
        "the rooster that crowed in the morn",
        "the farmer sowing his corn",
        "the horse and the hound and the horn"
    };
    //12

    static string[] what = new string[]
    {
        "that lay in",
        "that ate",
        "that killed",
        "that worried",
        "that tossed",
        "that milked",
        "that kissed",
        "that married",
        "that woke",
        "that kept",
        "that belonged to"
    };
    //11

    public static string Recite(int verseNumber)
    {
        StringBuilder rhyme = new StringBuilder();

        rhyme.Append("This is " + whom[verseNumber - 1]);

        for (int i = verseNumber - 1; i > 0; i--)
        {
            rhyme.Append(" " + what[i - 1] + " " + whom[i - 1]);
        }

        return rhyme.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        StringBuilder rhyme = new StringBuilder();

        for (int i = startVerse; i <= endVerse; i++)
        {
            rhyme.Append("This is " + whom[i - 1]);

            for (int j = i - 1; j > 0; j--)
            {
                rhyme.Append(" " + what[j - 1] + " " + whom[j - 1]);
            }

            if (i != endVerse)
                rhyme.Append("\n");
        }

        return rhyme.ToString();
    }
}