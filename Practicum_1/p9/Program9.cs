using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p9
{
    internal class Program9
    {
        static void Main(string[] args)
        {
            Console.Write("Сумма вклада = ");
            float sum = float.Parse(Console.ReadLine());
            Console.Write("Процент по вкладу = ");
            float pr = float.Parse(Console.ReadLine());
            Console.WriteLine("Через год сумма на вкладе = {0:C2}", sum * pr / 100 + sum); // такая же проблема с рублями
        }
    }
}
