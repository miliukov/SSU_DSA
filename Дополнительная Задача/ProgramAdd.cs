using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main()
    {
        string sourceString = GenerateRandomString(100000);
        string searchString = GenerateRandomString(3);

        Stopwatch stopwatch = new Stopwatch();

        // Прямой поиск подстроки в строке
        stopwatch.Start();
        int index1 = sourceString.IndexOf(searchString);
        stopwatch.Stop();
        Console.WriteLine("Время выполнения прямого поиска подстроки в строке: " + stopwatch.Elapsed);

        stopwatch.Reset();

        // Алгоритм Карпа-Рабина
        stopwatch.Start();
        int index2 = RabinKarpAlgorithm(sourceString, searchString);
        stopwatch.Stop();
        Console.WriteLine("Время выполнения алгоритма Карпа-Рабина: " + stopwatch.Elapsed);
    }

    static string GenerateRandomString(int length)
    {
        Random random = new Random();
        const string chars = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    static int RabinKarpAlgorithm(string t, string s)
    {
        const long P = 37;
        //вычисляем массив степеней P
        long[] pwp = new long[t.Length];
        pwp[0] = 1;
        for (int i = 1; i < t.Length; i++)
        {
            pwp[i] = pwp[i - 1] * P;
        }
        //вычисляем массив хэш-значение для всех префиксов строки T
        long[] h = new long[t.Length];
        for (int i = 0; i < t.Length; i++)
        {
            h[i] = (t[i] - 'a' + 1) * pwp[i]; //1
            if (i > 0)
                h[i] += h[i - 1];
        }
        // вычисляем хэш-значение для подстроки S
        long h_s = 0;
        for (int i = 0; i < s.Length; i++)
        {
            h_s += (s[i] - 'a' + 1) * pwp[i];
        }
        //проводим поиск по хеш-значениям
        for (int i = 0; i + s.Length - 1 < t.Length; i++)
        {
            // находим хэш-значение подстроки T начиная с позиции i длиною s.Length
            long cur_h = h[i + s.Length - 1];
            if (i > 0)
            {
                cur_h -= h[i - 1];
            }
            //приводим хэш-значения двух подстрок к одной степени
            if (cur_h == h_s * pwp[i]) // если хеш-значения равны, то и подстроки равны
            {
                return i;
            }
        }
        return -1;
    }
}
