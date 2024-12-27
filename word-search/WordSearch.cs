using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public class WordSearch
{
    private List<string> gridrows = new List<string>();
    private int rows;
    private int cols;

    private (int, int)[] directions = new (int, int)[8]
    { (1, 0), (-1, 0), (0, 1), (0, -1), (1, 1), (-1, 1), (1, -1), (-1, -1) };
    public WordSearch(string grid)
    {
        gridrows = grid.Split('\n').ToList();
        rows = gridrows.Count;
        cols = gridrows[0].Count();
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        var wordsPos = new Dictionary<string, ((int, int), (int, int))?>();
        var start = (0, 0);
        var end = (0, 0);

        int i = 1;
        int j = 1;

        foreach (var word in wordsToSearchFor)
        {
            int wordCount = 0;

            for (i = 0; i < rows; i++)
            {
                for (j = 0; j < cols; j++)
                {
                    if (gridrows[i][j] == word[0])
                    {
                        start = (j, i);

                        foreach (var direction in directions)
                        {
                            int counter = 0;
                            end = (j, i);
                            try
                            {
                                foreach (var letter in word)
                                {
                                    if (gridrows[end.Item2][end.Item1] == letter)
                                    {
                                        end.Item1 += direction.Item1;
                                        end.Item2 += direction.Item2;
                                        counter++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                if (counter == word.Length)
                                {
                                    start = (start.Item1 + 1, start.Item2 + 1);
                                    end = (end.Item1 - direction.Item1 + 1, end.Item2 - direction.Item2 + 1);
                                    wordsPos.Add(word, (start, end));
                                    wordCount++;
                                }
                            }
                            catch (Exception)
                            {
                                // out of range
                            }
                        }
                    }
                }
            }

            if (wordCount == 0)
                wordsPos.Add(word, null);
        }

        return wordsPos;
    }
}