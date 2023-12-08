using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
/* составить инвентарную ведомость игрушек, включив: 
 * название игрушки, ее стоимость (в руб.), возрастные границы детей,
 * для которых предназначена игрушка. Вывести в новый файл информацию 
 * о тех игрушках, которые предназначены для детей от N до M лет, сгруппировав их по названию.
*/
struct Toy
{
    public string Name;
    public double Cost;
    public int MinAge;
    public int MaxAge;
}

class Program16_2
{
    static void Main()
    {
        List<Toy> toys = new List<Toy>();

        // Чтение данных из файла
        string[] lines = File.ReadAllLines("D:\\.program\\C#\\SSU_DSA\\Pr_16_II\\input.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            Toy toy = new Toy
            {
                Name = parts[0],
                Cost = double.Parse(parts[1]),
                MinAge = int.Parse(parts[2]),
                MaxAge = int.Parse(parts[3])
            };
            toys.Add(toy);
        }

        // Фильтрация игрушек по возрастным границам
        int minAge = 3; // Пример значений N и M
        int maxAge = 6;
        List<Toy> filteredToys = toys.FindAll(t => t.MinAge <= minAge && t.MaxAge >= maxAge);

        // Группировка игрушек по названию
        var groupedToys = filteredToys.GroupBy(t => t.Name);

        // Запись информации в новый файл
        using (StreamWriter sw = new StreamWriter("D:\\.program\\C#\\SSU_DSA\\Pr_15_II\\output.txt"))
        {
            foreach (var group in groupedToys)
            {
                sw.WriteLine($"Название: {group.Key}");
                foreach (var toy in group)
                {
                    sw.WriteLine($"Стоимость: {toy.Cost} руб., возрастные границы: {toy.MinAge}-{toy.MaxAge} лет");
                }
                sw.WriteLine();
            }
        }
    }
}
