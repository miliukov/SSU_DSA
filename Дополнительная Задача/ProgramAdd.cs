using System;
using System.Diagnostics;
using System.IO;
using System.Text;

class Program
{
    static int NaiveSearch(string text, string pattern)
    {
        int n = text.Length;
        int m = pattern.Length;

        for (int i = 0; i <= n - m; i++)
        {
            int j;
            for (j = 0; j < m; j++)
            {
                if (text[i + j] != pattern[j])
                    break;
            }
            if (j == m)
                return i;
        }
        return -1;
    }

    static int RabinKarpSearch(string text, string pattern)
    {
        int n = text.Length;
        int m = pattern.Length;
        int d = 256; // размер алфавита
        int q = 101; // простое число

        int h = 1;
        for (int i = 0; i < m - 1; i++)
            h = (h * d) % q;

        int p = 0; // хеш для pattern
        int t = 0; // хеш для text
        for (int i = 0; i < m; i++)
        {
            p = (d * p + pattern[i]) % q;
            t = (d * t + text[i]) % q;
        }

        for (int i = 0; i <= n - m; i++)
        {
            if (p == t)
            {
                int j;
                for (j = 0; j < m; j++)
                {
                    if (text[i + j] != pattern[j])
                        break;
                }
                if (j == m)
                    return i;
            }
            if (i < n - m)
            {
                t = (d * (t - text[i] * h) + text[i + m]) % q;
                if (t < 0)
                    t = (t + q);
            }
        }
        return -1;
    }

    static void Main()
    {
        string text = File.ReadAllText("D:\\.program\\C#\\SSU_DSA\\Дополнительная Задача\\input.txt", Encoding.UTF8).ToLower();
        string pattern = "гъп";

        Stopwatch stopwatch = new Stopwatch();
        int index = 0;
        stopwatch.Start();
        index = NaiveSearch(text, pattern);
        stopwatch.Stop();
        Console.WriteLine("Индекс искомой подстроки: " + index);
        Console.WriteLine("Время выполнения прямого поиска: " + stopwatch.Elapsed);

        stopwatch.Reset();

        stopwatch.Start();
        index = RabinKarpSearch(text, pattern);
        stopwatch.Stop();
        Console.WriteLine("Индекс искомой подстроки: " + index);
        Console.WriteLine("Время выполнения алгоритма Карпа-Рабина: " + stopwatch.Elapsed);
    }
}
