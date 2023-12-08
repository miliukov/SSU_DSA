using System;
using System.IO;
/* автомобильная ведомость: марка автомобиля, номер автомобиля, фамилия его владельца, год
приобретения, пробег, вывести в новый файл информацию об автомобилях,
выпущенных ранее определенного года, отсортировав их по пробегу */
struct Car : IComparable<Car>
{
    public string Brand;
    public string Number;
    public string Owner;
    public int Year;
    public int Mileage;
    public int CompareTo(Car other)
    {
        return - Mileage.CompareTo(other.Mileage);
    }
}
class Program14_2
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("D:\\.program\\C#\\SSU_DSA\\Pr_14_II\\input.txt");
        Car[] cars = new Car[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            cars[i] = new Car
            {
                Brand = parts[0].Trim(),
                Number = parts[1].Trim(),
                Owner = parts[2].Trim(),
                Year = int.Parse(parts[3]),
                Mileage = int.Parse(parts[4])
            };
        }
        Array.Sort(cars);
        int targetYear = 2014;
        using (StreamWriter writer = new StreamWriter("D:\\.program\\C#\\SSU_DSA\\Pr_14_II\\output.txt"))
        {
            foreach (Car car in cars)
            {
                if (car.Year < targetYear)
                {
                    writer.WriteLine($"{car.Brand}, {car.Number}, {car.Owner}, {car.Year}, {car.Mileage}");
                }
            }
        }
    }
}
