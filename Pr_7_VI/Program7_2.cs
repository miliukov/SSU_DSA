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

        bool equal = false;
        int k = 0;

        
    }

    bool isEqual(int[][] array)
    {
        int k = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i][k] != array[k][i])
            {
                return false;
            }
            k++;
        }
        return true;
    }
}
