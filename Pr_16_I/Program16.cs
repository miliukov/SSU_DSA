using System;
using System.IO;
using System.Linq;

class Program16
{
    static void Main()
    {
        // Чтение данных из файла
        using (StreamReader sr = new StreamReader("D:\\.program\\C#\\SSU_DSA\\Pr_16_I\\input.txt"))
        {
            string content = sr.ReadToEnd();
            string[] numberStrings = content.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = Array.ConvertAll(numberStrings, int.Parse);

            // Использование первого числа в качестве порогового значения
            int threshold = numbers[0];

            // Фильтрация и преобразование элементов
            var filteredNumbers = numbers.Skip(1).Where(num => num > threshold).Select(num => num / 3).OrderByDescending(num => num);
            // Запись результата в файл
            using (StreamWriter sw = new StreamWriter("D:\\.program\\C#\\SSU_DSA\\Pr_15_I\\output.txt"))
            {
                foreach (var num in filteredNumbers)
                {
                    sw.WriteLine(num);
                }
            }
        }
    }
}