using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 
вывести простые числа на [a, b]
найти количество простых чисел на [a, b]
найти сумму составных чисел на [a, b]
для А вывести ближайшее предшествующее по отношению к нему простое число
*/
namespace Pr_5_II
{
    internal class Program5
    {
        static bool IsPrime(int a)
        {
            if (a <= 1) return false;
            for (int i = 2; i < (int) a / 2; i++)
            {
                if (a % i == 0) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Все простые числа на отрезке от {0} до {1}: ", a, b);
            int c = 0;
            int sum = 0;
            for (int i = a; i <= b; i++)
            {
                if (IsPrime(i))
                {
                    Console.Write(i + " ");
                    c++;
                }
                else sum += i;
            }
            Console.WriteLine("\nИх количество = {0}", c);
            Console.WriteLine("Сумма составных чисел = {0}", sum);
            Console.Write("A = ");
            int A = int.Parse(Console.ReadLine());
            for (int i = 0;;i++)
            {
                if (IsPrime(A + i))
                {
                    Console.WriteLine("Ближайшее к A простое число = {0}", A + i);
                    break;
                }
                else if (IsPrime(A - i))
                {
                    Console.WriteLine("Ближайшее к A простое число = {0}", A - i);
                    break;
                }
            }
        }
    }
}
