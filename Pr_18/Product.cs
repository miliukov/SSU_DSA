using System;

namespace Pr_18
{
    [Serializable]
    abstract class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public abstract void DisplayInfo();

        public bool IsExpired(DateTime currentDate)
        {
            return currentDate > ExpiryDate;
        }
        public int CompareTo(Product other)
        {
            if (other == null)
                return 1;

            return this.Price.CompareTo(other.Price);
        }
    }
}
