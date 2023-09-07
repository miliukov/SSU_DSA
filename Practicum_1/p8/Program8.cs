using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p8
{
    internal class Program8
    {
        static void Main(string[] args)
        {
            Console.Write("Сумма вклада = ");
            float sum = float.Parse(Console.ReadLine());
            Console.Write("Процент по вкладу = ");
            float pr = float.Parse(Console.ReadLine());
            Console.WriteLine("Через год начислят = {0:C2}", sum * pr / 100); // такая же проблема с рублями
        }
    }
}
