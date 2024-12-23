using System;
using System.Linq;

public static class Rectangles
{
    public static int Count(string[] rows)
    {
        if(rows.Length == 0)
        {
            return 0;
        }

        int row = rows.Length;
        int col = rows[0].Length;
        int count = 0;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if(rows[i][j] == '+')
                {
                    for (int k = i+1; k < row; k++)
                    {
                        for (int l = j+1; l < col; l++)
                        {
                            if(rows[i][l] == '+' && rows[k][j] == '+' && rows[k][l] == '+')
                            {
                                if(rectangleCheck(rows, i, j, k, l))
                                {
                                    count++;
                                }
                            }
                        }
                    }
                }
            }
        }
        return count;
    }

    static bool rectangleCheck(string[] rows, int top, int left, int bottom, int right)
    {
        for (int i = top + 1; i < bottom; i++)
        {
            if (rows[i][left] != '|' && rows[i][left] != '+')
                return false;
            if (rows[i][right] != '|' && rows[i][right] != '+')
                return false;
        }

        for (int j = left + 1; j < right; j++)
        {
            if (rows[top][j] != '-' && rows[top][j] != '+')
                return false;
            if (rows[bottom][j] != '-' && rows[bottom][j] != '+')
                return false;
        }

        return true;
    }
}
