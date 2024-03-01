using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using Pr_18;

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>();
        string[] lines = File.ReadAllLines("D:\\.program\\C#\\SSU_DSA\\Pr_18\\products.txt");

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');

            if (parts.Length >= 6)
            {
                string type = parts[0].Trim();
                string name = parts[1].Trim();
                double price = double.Parse(parts[2].Trim());
                DateTime productionDate = DateTime.Parse(parts[4].Trim());
                DateTime expiryDate = DateTime.Parse(parts[5].Trim());

                switch (type)
                {
                    case "Item":
                        int quantity = int.Parse(parts[3].Trim());
                        products.Add(new Item
                        {
                            Name = name,
                            Price = price,
                            Quantity = quantity,
                            ProductionDate = productionDate,
                            ExpiryDate = expiryDate
                        });
                        break;

                    case "Batch":
                        int batchQuantity = int.Parse(parts[3].Trim());
                        products.Add(new Batch
                        {
                            Name = name,
                            Price = price,
                            Quantity = batchQuantity,
                            ProductionDate = productionDate,
                            ExpiryDate = expiryDate
                        });
                        break;

                    case "Bundle":
                        List<Product> bundleProducts = new List<Product>();
                        string[] bundleProductNames = parts[3].Trim().Split(';');
                        foreach (string productName in bundleProductNames)
                        {
                            string[] productInfo = productName.Trim().Split('|');
                            if (productInfo.Length >= 5)
                            {
                                string productType = productInfo[0].Trim();
                                string productNameInBundle = productInfo[1].Trim();
                                double productPrice = double.Parse(productInfo[2].Trim());
                                int productQuantity = int.Parse(productInfo[3].Trim());
                                DateTime productProductionDate = DateTime.Parse(productInfo[4].Trim());
                                DateTime productExpiryDate = DateTime.Parse(productInfo[5].Trim());

                                Product productToAdd = null;
                                if (productType == "Item")
                                {
                                    productToAdd = new Item
                                    {
                                        Name = productNameInBundle,
                                        Price = productPrice,
                                        Quantity = productQuantity,
                                        ProductionDate = productProductionDate,
                                        ExpiryDate = productExpiryDate
                                    };
                                }

                                if (productToAdd != null)
                                    bundleProducts.Add(productToAdd);
                            }
                        }
                        products.Add(new Bundle
                        {
                            Name = name,
                            Price = price,
                            Products = bundleProducts,
                            ProductionDate = productionDate,
                            ExpiryDate = expiryDate
                        });
                        break;
                }
            }
        }
        products.Sort();
        // Сериализуем список товаров и записываем его в файл
        SerializeProducts(products, "D:\\.program\\C#\\SSU_DSA\\Pr_18\\products.dat");
        
        List<Product> products1 = LoadProducts("D:\\.program\\C#\\SSU_DSA\\Pr_18\\products.dat");

        if (products1 != null)
        {
            Console.WriteLine("**Вся информация о продуктах:**");
            foreach (var product in products1)
            {
                product.DisplayInfo();
            }
            DateTime currentDate = DateTime.Now;
            Console.WriteLine("\n**Срок годности вышел:**");
            foreach (var product in products1)
            {
                if (product.IsExpired(currentDate))
                {
                    product.DisplayInfo();
                }
            }
        }
        else
        {
            Console.WriteLine("Не получилось загрузить список.");
        }
    }
    static void SerializeProducts(List<Product> products, string filePath)
    {
        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, products);
        }
    }

    static List<Product> LoadProducts(string filePath)
    {
        List<Product> products = null;

        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            products = (List<Product>)formatter.Deserialize(fileStream);
        }
        return products;
    }
}
