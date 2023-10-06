using System;
// удалить из массива k-тую строку и j-тый столбец, если их значения совпадают
namespace Pr_7_VI
{
    class Program7_2
    {
        static void Main()
        {
            // Исходный ступенчатый массив
            int[][] array = new int[][]
            {
            new int[] { 1, 2, 3 },
            new int[] { 2, 5, 8 },
            new int[] { 7, 8, 9 }
            };

            int k = 1; // строка
            int j = 1; // столбец

            bool allValuesMatch = true;
            int j_ = -1;
            for (int i = 0; i < array.Length; i++)
            {
                j_++;
                if (array[i][k] != array[j][j_])
                {
                    allValuesMatch = false;
                    break;
                }
            }

            if (allValuesMatch)
            {
                array = RemoveRow(array, k);
                array = RemoveColumn(array, j);
            }

            Console.WriteLine("Результат:");
            for (int i = 0; i < array.Length; i++)
            {
                for (int c = 0; c < array[i].Length; c++)
                {
                    Console.Write(array[i][c] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[][] RemoveRow(int[][] array, int rowIndex)
        {
            int[][] newArray = new int[array.Length - 1][];
            for (int i = 0, j = 0; i < array.Length; i++)
            {
                if (i != rowIndex)
                {
                    newArray[j] = array[i];
                    j++;
                }
            }
            return newArray;
        }

        static int[][] RemoveColumn(int[][] array, int columnIndex)
        {
            int[][] newArray = new int[array.Length][];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = new int[array[i].Length - 1];
                for (int j = 0, c = 0; j < array[i].Length; j++)
                {
                    if (j != columnIndex)
                    {
                        newArray[i][c] = array[i][j];
                        c++;
                    }
                }
            }
            return newArray;
        }
    }
}

