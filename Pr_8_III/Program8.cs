using System;
// найти все самые короткие слова сообщения
namespace Pr_8_III
{
    class Program8
    {
        static void Main()
        {
            string message = "Дана строка. Сделаем вид, что тут содержится осмысленное текстовое сообщение.";

            string[] words = message.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            int minLength = int.MaxValue;
            foreach (string word in words)
            {
                if (word.Length < minLength)
                {
                    minLength = word.Length;
                }
            }

            Console.WriteLine("Самые короткие слова в сообщении:");
            foreach (string word in words)
            {
                if (word.Length == minLength)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }

}