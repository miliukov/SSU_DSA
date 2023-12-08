using System;
using System.IO;
using System.Linq;
// инвентарная ведомость игрушек
struct Toy
{
    public string Name;
    public decimal Price;
    public int MinAge;
    public int MaxAge;
}

class Program
{
    static void Main()
    {
        // Чтение данных об игрушках из файла
        string[] toyData = File.ReadAllLines("D:\\.program\\C#\\SSU_DSA\\Pr_15_II\\input.txt");
        Toy[] toys = new Toy[toyData.Length];
        for (int i = 0; i < toyData.Length; i++)
        {
            string[] parts = toyData[i].Split(',');
            toys[i] = new Toy
            {
                Name = parts[0],
                Price = decimal.Parse(parts[1]),
                MinAge = int.Parse(parts[2]),
                MaxAge = int.Parse(parts[3])
            };
        }

        // Возрастные границы
        int minAge = 3;
        int maxAge = 6;

        // Фильтрация игрушек по возрастным границам
        var filteredToys = from toy in toys
                           where toy.MinAge <= minAge && toy.MaxAge >= maxAge
                           group toy by toy.Name into toyGroup
                           select new
                           {
                               Name = toyGroup.Key,
                               Toys = toyGroup.ToList()
                           };

        // Запись информации о подходящих игрушках в новый файл
        using (StreamWriter writer = new StreamWriter("D:\\.program\\C#\\SSU_DSA\\Pr_15_II\\output.txt"))
        {
            foreach (var group in filteredToys)
            {
                writer.WriteLine($"Название: {group.Name}");
                foreach (var toy in group.Toys)
                {
                    writer.WriteLine($"Стоимость: {toy.Price} руб., Возраст: от {toy.MinAge} до {toy.MaxAge} лет");
                }
                writer.WriteLine();
            }
        }
    }
}
