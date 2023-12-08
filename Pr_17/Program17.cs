using System;
using System.Text;

namespace Pr_17
{
    class Program17
    {
        static void Main()
        {
            StringManipulator sm = new StringManipulator("Привет, Мир!");

            Console.WriteLine("Исходная строка: " + sm.Line);
            Console.WriteLine("Количество пробелов: " + sm.CountSpaces());

            sm.ConvertToLowerCase();
            Console.WriteLine("Строка в нижнем регистре: " + sm.Line);

            sm.RemovePunctuation();
            Console.WriteLine("Строка без знаков препинания: " + sm.Line);

            Console.WriteLine("Длина строки: " + sm.Length);

            sm.Line = "Лалалала лала лал";
            Console.WriteLine("Новое значение строки: " + sm.Line);

            Console.WriteLine("Символ по индексу 2: " + sm[2]);

            StringManipulator sm2 = new StringManipulator("привет");
            Console.WriteLine("Проверка на равенство: " + (sm & sm2));

            StringBuilder sb = (StringBuilder)sm;
            Console.WriteLine("Преобразование в StringBuilder: " + sb.ToString());

            StringManipulator sm3 = (StringManipulator)sb;
            Console.WriteLine("Обратное преобразование в StringManipulator: " + sm3.Line);
        }
    }
}
