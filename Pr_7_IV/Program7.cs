using System;
// найти сумму элементов с номерами от k1 до k2 и записать данные в новый массив
namespace Pr_7_IV
{
    internal class Program7
    {
        static void Main(string[] args)
        {
            int n = 5; // размер массива
            int k1 = 2; // начальный индекс
            int k2 = 4; // конечный индекс

            int[,] array = new int[n, n];
            int[] resultArray = new int[n];

            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = random.Next(10);
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                resultArray[i] = 0;
                for (int j = k1; j <= k2; j++)
                {
                    resultArray[i] += array[i, j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(resultArray[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
