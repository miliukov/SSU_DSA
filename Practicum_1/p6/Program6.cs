using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p6
{
    internal class Program6
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            float a = float.Parse(Console.ReadLine());
            Console.Write("b = ");
            float b = float.Parse(Console.ReadLine());
            Console.Write("c = ");
            float c = float.Parse(Console.ReadLine());
            Console.WriteLine("({0:F2} + {1:F2}) + {2:F2} = {0:F2} + ({1:F2} + {2:F2})", a, b, c);
        }
    }
}
