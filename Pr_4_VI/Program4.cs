using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// сократить дробь вида a/b
namespace Pr_4_VI
{
    internal class Program4
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            int a = Math.Abs(int.Parse(Console.ReadLine()));
            Console.Write("b = ");
            int b = Math.Abs(int.Parse(Console.ReadLine()));
            if (a == 0) Console.WriteLine(a);
            else if (b == 0) Console.WriteLine("Деление на 0 невозможно");
            else
            {
                int i = a;
                int j = b;
                while (j != 0)
                {
                    if (i > j) i -= j;
                    else j -= i;
                }
                Console.WriteLine("{0}/{1}", a / i, b / i);
            }

        }
    }
}
