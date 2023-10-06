using System;
// перевод числа из p-ичной системы счисления в десятичную, (p>1, p≠10), рекурсия
namespace Pr_5_III
{
    internal class Program5_2
    {
        static int ConvertToDec(string number, int p, int index = 0)
        {
            // Проверка условия остановки рекурсии
            if (index == number.Length)
            {
                return 0;
            }
            // Рекурсивный вызов для следующего разряда
            return CharToDigit(number[index]) * (int)Math.Pow(p, number.Length - index - 1) + ConvertToDec(number, p, index + 1);
        }

        static int CharToDigit(char c) // перевод из char в int
        {
            if (Char.IsDigit(c))
            {
                return (int)Char.GetNumericValue(c);
            }
            else
            {
                return (int)(Char.ToUpper(c) - 'A' + 10);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ConvertToDec("101010", 3));
            Console.WriteLine(ConvertToDec("3E8", 15));
        }
    }
}
