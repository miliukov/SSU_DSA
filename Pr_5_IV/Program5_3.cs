using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// разработать рекурсивный метод для вывода на экран картинки
namespace Pr_5_IV
{
    internal class Program5_3
    {
        static void Stroka(int n, char a)
        {
            for (int i = 1; i <= n; ++i)
            {
                Console.Write(a);
            }
        }        
        static void Letters(int i, int n)
        {
            if (n > 0 && n >= 28)
            {

                Stroka(i, ' ');
                Stroka(n, (char)((int)'A' + i));
                Console.WriteLine();
                Letters(i + 1, n - 2);
                Stroka(i, ' ');
                Stroka(n, (char)((int)'A' + i));
                Console.WriteLine();
            }
        }

        static void Main()
        {
            Letters(0, 78);
        }
    }
}
