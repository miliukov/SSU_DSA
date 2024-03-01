using System;
using System.Text;

namespace Pr_17
{
    class Program
    {
        static void Main()
        {
            StringManipulator mainString = new StringManipulator("Привет, Мир!");
            Console.WriteLine("Исходная строка: " + mainString.Line);

            Console.WriteLine("Количество пробелов: " + mainString.CountSpaces());

            Console.WriteLine("Строка в нижнем регистре: " + mainString.ConvertToLowerCase().Line);

            Console.WriteLine("Строка без знаков препинания: " + mainString.RemovePunctuation().Line);

            Console.WriteLine("Длина строки: " + mainString.Length);

            Console.WriteLine("Строка в верхнем регистре: " + (+mainString).Line);

            Console.WriteLine("Строка в нижнем регистре: " + (-mainString).Line);

            Console.WriteLine("Пустая ли строка? " + (mainString ? "Нет" : "Да"));

            StringManipulator someString = new StringManipulator("привет, мир!");
            Console.WriteLine("Строки равны? " + (mainString & someString));

            StringBuilder sbString = (StringBuilder)mainString;
            Console.WriteLine("Преобразование в StringBuilder: " + sbString.ToString());

            StringManipulator smFromSBString = (StringManipulator)sbString;
            Console.WriteLine("Преобразование обратно в StringManipulator: " + smFromSBString.Line);
        }
    }

}
