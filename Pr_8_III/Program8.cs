using System;
using System.Collections.Generic;
using System.Linq;
// найти все самые короткие слова сообщения
namespace Pr_8_III
{
    class Program8
    {
        static void Main()
        {
            string message = "Дана строка. Сделаем вид, что тут содержится осмысленное текстовое сообщение.";

            string[] words = message.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> shortestWords = new List<string>();
            int minLength = int.MaxValue;

            foreach (string word in words)
            {
                if (word.Length < minLength)
                {
                    shortestWords.Clear();
                    minLength = word.Length;
                    shortestWords.Add(word);
                }
                else
                if (word.Length == minLength)
                {
                    shortestWords.Add(word);
                }
            }

            Console.WriteLine("Самые короткие слова в сообщении:");
            foreach (string word in shortestWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}