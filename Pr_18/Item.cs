using System;

namespace Pr_18
{
    [Serializable]
    class Item : Product
    {
        public int Quantity { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Название: {Name}\nЦена: {Price}\nДата изготовления: {ProductionDate.ToShortDateString()}\nГоден до: {ExpiryDate.ToShortDateString()}\nКоличество: {Quantity}\n");
        }
    }
}
