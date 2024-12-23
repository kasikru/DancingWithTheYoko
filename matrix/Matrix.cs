using System;
using System.Collections.Generic;

public class Matrix
{
    public Matrix(string input)
    {
        matrix = input;
    }
    public string matrix;


    private int[][] MatrixInfo()
    {
        List<int[]> matr = new List<int[]>();
        string[] rows = matrix.Split("\n");

        foreach (var item in rows)
        {
            string[] temp = item.Split(" ");
            int[] ints = new int[temp.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                ints[i] = Int32.Parse(temp[i]);
            }

            matr.Add(ints);
        }

        return matr.ToArray();
    }

    public int RowCount() => MatrixInfo().Length;
    public int ColumnCount() => MatrixInfo()[0].Length;

    public int[] Row(int row) => MatrixInfo()[row - 1];

    public int[] Column(int col)
    {
        int[] clmn = new int[RowCount()];

        for (int i = 0; i < RowCount(); i++)
        {
            clmn[i] = MatrixInfo()[i][col - 1];
        }

        return clmn;
    }
}