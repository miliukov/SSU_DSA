using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// два вещественных числа, выводит на экран произведение данных чисел (вещественные выводятся с точностью до 1 знака после запятой)
namespace Pr_1
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            float a = float.Parse(Console.ReadLine());
            Console.Write("b = ");
            float b = float.Parse(Console.ReadLine());
            Console.WriteLine("{0:F1} * {1:F1} = {2:F1}", a, b, a * b);
        }
    }
}
