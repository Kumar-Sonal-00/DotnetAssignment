using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Price_Updation
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        // Method to update the price based on the given conditions
        public void UpdatePrice()
        {
            if (Price < 1000)
            {
                Price *= 1.10; // Increase price by 10%
            }
            else if (Price >= 1000 && Price <= 5000)
            {
                Price *= 1.05; // Increase price by 5%
            }
            // No change if price is above 5000
        }

        public override string ToString()
        {
            return $"{Id},{Name},{Price:F2}";
        }
    }
}
