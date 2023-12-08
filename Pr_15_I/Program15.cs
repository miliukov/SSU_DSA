using System;
using System.IO;
using System.Linq;
// в порядке убывания все элементы, большие заданного числа, уменьшив их в три раза.
class Program
{
    static void Main()
    {
        // Чтение последовательности целых чисел из файла
        string[] lines = File.ReadAllLines("D:\\.program\\C#\\SSU_DSA\\Pr_15_I\\input.txt");
        int[] numbers = Array.ConvertAll(lines, int.Parse);

        // Заданное число
        int startNum = 10;

        /// Фильтрация и преобразование элементов с использованием LINQ запросов
        var filter =    from num in numbers
                        where num > startNum
                        select num / 3;

        // Сортировка в порядке убывания с использованием LINQ запросов
        var result =    from num in filter
                        orderby num descending
                        select num;

        using (StreamWriter writer = new StreamWriter("D:\\.program\\C#\\SSU_DSA\\Pr_15_I\\output.txt"))
        {
            foreach (var num in result)
            {
                writer.WriteLine(num);
            }
        }
    }
}
