using System;
using System.Collections.Generic;

namespace Pr_18
{
    [Serializable]
    class Bundle : Product
    {
        public List<Product> Products { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Название: {Name}\nЦена: {Price}\nГоден до: {ExpiryDate.ToShortDateString()}");
            Console.WriteLine("Продукты в наборе:\n");
            foreach (var product in Products)
            {
                Console.Write("*");
                product.DisplayInfo();
            }
            Console.WriteLine();
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
