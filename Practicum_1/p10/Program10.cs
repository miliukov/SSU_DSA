using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p10
{
    internal class Program10
    {
        static void Main(string[] args)
        {
            Console.Write("Как тебя зовут? ");
            string name = Console.ReadLine();
            Console.Write("Сколько тебе лет? ");
            byte age = byte.Parse(Console.ReadLine());
            Console.WriteLine("{0}, ты родился в {1} году.", name, System.DateTime.Today.Year - age);
        }
    }
}
