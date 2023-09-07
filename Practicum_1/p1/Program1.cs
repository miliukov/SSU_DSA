using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.Write("a = "); // выводим строку в консоль
            int a = int.Parse(Console.ReadLine()); // читаем строку и переводим её в int
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("{0} + {1} = {2}", a, b, a + b); // при выводе вместо "{0}" будет аргумент переменная "a" и тд

        }
    }
}
