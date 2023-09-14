using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// все двузначные числа, сумма цифр которых четная
namespace Pr_3_IV
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            for(int i = 10; i <= 99; i++)
            {
                if (((i / 10) + (i % 10)) % 2 == 0) Console.WriteLine(i);
            }
        }
    }
}
