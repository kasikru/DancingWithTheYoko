using System;
using System.Collections.Generic;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        int[][] triangle = new int[rows][];

        if (rows == 0)
            return triangle;

        triangle[0] = new int[1];
        triangle[0][0] = 1;

        if (rows > 1)
        {
            triangle[1] = new int[2] { 1, 1 };
        }

        for (int i = 2; i < rows; i++)
        {
            triangle[i] = new int[i + 1];
            triangle[i][0] = 1;

            for (int j = 1; j < i; j++)
            {
                triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
            }

            triangle[i][i] = 1;

        }

        return triangle;
    }

}