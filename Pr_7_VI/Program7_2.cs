using System;
using System.Collections.Generic;
// удалить одинаковые столбцы и строки
class Program
{
    static void Main()
    {
        int[][] array = new int[][] {
            new int[] { 1, 2, 3 },
            new int[] { 2, 3, 4 },
            new int[] { 3, 4, 5 }
        };

        int rowCount = array.Length;
        int colCount = array[0].Length;

        List<int> rowsToRemove = new List<int>();
        List<int> colsToRemove = new List<int>();

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = i + 1; j < rowCount; j++)
            {
                bool isRowEqual = true;
                bool isColEqual = true;

                for (int k = 0; k < colCount; k++)
                {
                    if (array[i][k] != array[j][k])
                    {
                        isRowEqual = false;
                        break;
                    }
                }

                if (isRowEqual && !rowsToRemove.Contains(i) && !rowsToRemove.Contains(j))
                {
                    rowsToRemove.Add(j);
                }

                for (int k = 0; k < rowCount; k++)
                {
                    if (array[k][i] != array[k][j])
                    {
                        isColEqual = false;
                        break;
                    }
                }

                if (isColEqual && !colsToRemove.Contains(i) && !colsToRemove.Contains(j))
                {
                    colsToRemove.Add(j);
                }
            }
        }

        int[][] newArray = new int[rowCount - rowsToRemove.Count][];
        int newRow = 0;

        for (int i = 0; i < rowCount; i++)
        {
            if (!rowsToRemove.Contains(i))
            {
                int[] newRowArray = new int[colCount - colsToRemove.Count];
                int newCol = 0;

                for (int j = 0; j < colCount; j++)
                {
                    if (!colsToRemove.Contains(j))
                    {
                        newRowArray[newCol] = array[i][j];
                        newCol++;
                    }
                }

                newArray[newRow] = newRowArray;
                newRow++;
            }
        }

        for (int i = 0; i < newArray.Length; i++)
        {
            for (int j = 0; j < newArray[i].Length; j++)
            {
                Console.Write(newArray[i][j] + " ");
            }

            Console.WriteLine();
        }
    }
}
