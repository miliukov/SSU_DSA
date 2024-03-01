using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jarray
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите элементы зубчатого целочисленного массива:");

            // Считываем зубчатый массив
            int[][] mainArray = ReadArray();

            // Выводим исходный массив
            Console.WriteLine("\nИсходный массив:");
            PrintArray(ref mainArray);

            // Удаляем одинаковые строки и столбцы
            RemoveDuplicateRowsAndColumns(ref mainArray);

            // Выводим результат
            Console.WriteLine("\nМассив после удаления одинаковых строк и столбцов:");
            PrintArray(ref mainArray);

            Console.ReadLine();
        }

        static int[][] ReadArray()
        {
            //массив для считывания
            int[][] array = new int[0][];
            int rowCounter = 0;

            string line;
            //пока читается не пуста строка - читаем строку из консоли
            while ((line = Console.ReadLine()) != null && line.Trim() != "")
            {
                //получаем массив значений разделенных пробелами
                string[] values = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                //формируем новый целочисленный одномерный массив для считанных значений
                int[] row = new int[values.Length];

                //преобразуем каждый считанный элемент в число и помещаем его в массив
                for (int i = 0; i < values.Length; i++)
                {
                    if (int.TryParse(values[i], out int num))
                    {
                        row[i] = num;
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка: Невозможно преобразовать значение '{values[i]}' в число. Повторите ввод.");
                        return null;
                    }
                }

                //изменяем исходный массив добавляем в него строку
                Array.Resize(ref array, rowCounter + 1);
                //помещаем считанную строку в зубчатый массив
                array[rowCounter] = row;
                rowCounter++;
            }

            return array;
        }

        static void PrintArray(ref int[][] array)
        {
            //цикл по строкам
            foreach (int[] row in array)
            {
                //цикл по элементам внутри текущей строки
                foreach (int num in row)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }

        static void RemoveDuplicateRowsAndColumns(ref int[][] array)
        {
            int rows = array.Length;

            int cols = 0;
            foreach (int[] row in array)
            {
                if (row.Length > cols) cols = row.Length;
            }



            // Массивы для хранения номеров строк и столбцов, подлежащих удалению
            bool[] rowsToDelete = new bool[rows];
            bool[] colsToDelete = new bool[cols];

            // Сравниваем строки поэлементно
            for (int i = 0; i < rows; i++)
            {
                for (int k = i + 1; k < rows; k++)
                {
                    //если строка не к удалению и длины стравниваем строк совпадают
                    if (!rowsToDelete[k] && array[i].Length == array[k].Length)
                    {
                        //предполагаем, что строки одинаковые
                        bool areEqual = true;

                        //если два сравниваемых элемента в строках не совпали - строки не равны
                        for (int m = 0; m < array[i].Length; m++)
                        {
                            if (array[i][m] != array[k][m])
                            {
                                areEqual = false;
                                break;
                            }
                        }

                        //если в результате строки равны - помечаем обе строки к удалению
                        if (areEqual)
                        {
                            rowsToDelete[i] = true;
                            rowsToDelete[k] = true;
                        }
                    }
                }
            }

            // Сравниваем столбцы поэлементно
            for (int j = 0; j < cols; j++)
            {
                for (int k = j + 1; k < cols; k++)
                {
                    //если столбец не помечен к удалению
                    if (!colsToDelete[k])
                    {
                        //предполагаем, что сравниваемые столбцы равны
                        bool areEqual = true;

                        for (int m = 0; m < rows; m++)
                        {
                            //если столбец не помечен к удалению пробуем сравнить соответствующие позиции столбцов
                            //т.к. нет встроеного метода возвращающего длину столбца, то будем использовать перехват исключения переполнения диапазона
                            try
                            {
                                if (array[m][j] != array[m][k])
                                {
                                    areEqual = false;
                                    break;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                areEqual = false;
                                break;
                            }
                        }

                        if (areEqual)
                        {
                            colsToDelete[j] = true;
                            colsToDelete[k] = true;
                        }
                    }
                }
            }

            //сравниваем строки и столбцы
            for (int r = 0; r < array.Length; r++)
            {
                //если максимальная длина столбца (равная колич-ву строк) совпадает с длиной строки - тогда сравниваем

                //цикл по столбцам
                for (int m = 0; m < array[r].Length; m++)
                {
                    if (array.Length == array[r].Length)
                    {
                        //предполагаем, что строки одинаковые
                        bool areEqual = true;

                        for (int l = 0; l < array.Length; l++)
                        {
                            if ((array[r].Length != array[l].Length) ||
                                    (array[r][l] != array[l][m]))
                            {
                                areEqual = false;
                                break;
                            }
                        }

                        //если в результате строки равны - помечаем обе строки к удалению
                        if (areEqual)
                        {
                            rowsToDelete[r] = true;
                            colsToDelete[m] = true;
                        }
                    }
                }
            }


            //удаляем отмеченные строки
            int curPos = 0;
            while (CountTrueValues(ref rowsToDelete) > 0)
            {

                if (rowsToDelete[curPos])
                {
                    for (int j = curPos + 1; j < rowsToDelete.Length; j++)
                    {
                        array[j - 1] = array[j];
                    }

                    Array.Resize(ref array, array.Length - 1);

                    for (int j = curPos; j < rowsToDelete.Length - 1; j++)
                    {
                        rowsToDelete[j] = rowsToDelete[j + 1];
                    }
                    Array.Resize(ref rowsToDelete, rowsToDelete.Length - 1);
                }
                else
                    curPos++;
            }

            //удаляем отмеченные столбцы
            curPos = 0;
            while (CountTrueValues(ref colsToDelete) > 0)
            {
                if (colsToDelete[curPos])
                {
                    //цикл по строкам
                    for (int i = 0; i < array.Length; i++)
                    {
                        for (int j = curPos; j < array[i].Length - 1; j++)
                        {
                            array[i][j] = array[i][j + 1];
                        }
                        Array.Resize(ref array[i], array[i].Length - 1);
                    }

                    for (int j = curPos; j < colsToDelete.Length - 1; j++)
                    {
                        colsToDelete[j] = colsToDelete[j + 1];
                    }
                    Array.Resize(ref colsToDelete, colsToDelete.Length - 1);

                }
                else curPos++;

            }

        }

        //возвращает количество удаляемых столбцов
        static int CountTrueValues(ref bool[] array)
        {
            int count = 0;
            foreach (bool value in array)
            {
                if (value)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
