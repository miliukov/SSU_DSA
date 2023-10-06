using System;
// какая из цифр трехзначного числа больше: вторая или последняя
namespace Pr_2_II
{
    internal class Program2_2
    {
        static void Main(string[] args)
        {
            Console.Write("Число = ");
            byte num = byte.Parse(Console.ReadLine());
            Console.WriteLine((num % 100 / 10 > num % 100 % 10) ? ("Второе больше") : ("Третье больше"));
        }
    }
}
