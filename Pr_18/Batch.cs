using System;

namespace Pr_18
{
    [Serializable]
    class Batch : Product
    {
        public int Quantity { get; internal set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Название: {Name}\nЦена: {Price}\nДата изготовления: {ProductionDate.ToShortDateString()}\nГоден до: {ExpiryDate.ToShortDateString()}\n");
        }
    }

}
