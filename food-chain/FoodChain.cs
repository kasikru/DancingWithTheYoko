using System;
using System.Text;
using System.Collections.Generic;


public static class FoodChain
{
    static List<string> rhymes = new List<string>
    {
        "She swallowed the cow to catch the goat.\n",
        "She swallowed the goat to catch the dog.\n",
        "She swallowed the dog to catch the cat.\n",
        "She swallowed the cat to catch the bird.\n",
        "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.\n",
        "She swallowed the spider to catch the fly.\n",

    };

    static List<string> additions = new List<string>
    {
        "I don't know how she swallowed a cow!\n",
        "Just opened her throat and swallowed a goat!\n",
        "What a hog, to swallow a dog!\n",
        "Imagine that, to swallow a cat!\n",
        "How absurd to swallow a bird!\n",
        "It wriggled and jiggled and tickled inside her.\n",
        "I don't know why she swallowed the fly. Perhaps she'll die."
    };
    static List<string> animals = new List<string>
    {
        "horse",
        "cow",
        "goat",
        "dog",
        "cat",
        "bird",
        "spider",
        "fly"

    };


    public static string Recite(int verseNumber)
    {
        StringBuilder recite = new StringBuilder();

        recite.Append($"I know an old lady who swallowed a {animals[8 - verseNumber]}.\n");

        if (verseNumber == 8)
        {
            recite.Append("She's dead, of course!");
            return recite.ToString();
        }

        recite.Append(additions[7 - verseNumber]);

        if (verseNumber == 2)
        {
            recite.Append(rhymes[7 - verseNumber]);
            recite.Append(additions[8 - verseNumber]);
        }

        if (verseNumber > 2)
        {
            for (int i = 7 - verseNumber; i < 6; i++)
            {
                recite.Append(rhymes[i]);
            }

            recite.Append(additions[6]);

        }

        return recite.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        StringBuilder recite = new StringBuilder();

        for (int i = startVerse; i < endVerse; i++)
        {
            recite.Append(Recite(i) + "\n\n");
        }
        recite.Append(Recite(endVerse));

        return recite.ToString();
    }

}