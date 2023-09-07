using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p7
{
    internal class Program7
    {
        static void Main(string[] args)
        {
            Console.Write("Номинал купюры = ");
            short nominal = short.Parse(Console.ReadLine());
            Console.Write("Количество купюр = ");
            int amount = int.Parse(Console.ReadLine());
            Console.WriteLine("Количество денег = {0:C2}", nominal * amount); // вместо обычной буквы "р" выводится знак валюты рубля, который не поддерживается консолью
        }
    }
}
