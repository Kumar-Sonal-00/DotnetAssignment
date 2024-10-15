using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Price_Updation
{
    internal class ProductManager
    {

        private string inputFilePath;
        private string outputFilePath;

        public ProductManager(string inputFilePath, string outputFilePath)
        {
            this.inputFilePath = inputFilePath;
            this.outputFilePath = outputFilePath;
        }

        // Method to read products from the input file
        public List<Product> ReadProducts()
        {
            var products = new List<Product>();
            string[] lines = File.ReadAllLines(inputFilePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                int id = int.Parse(parts[0]);
                string name = parts[1];
                double price = double.Parse(parts[2]);

                var product = new Product(id, name, price);
                products.Add(product);
            }

            return products;
        }

        // Method to write updated products to the output file
        public void WriteProducts(List<Product> products)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var product in products)
                {
                    writer.WriteLine(product.ToString());
                }
            }
        }
        // Method to display the updated products in the console
        public void DisplayUpdatedProducts(List<Product> products)
        {
            Console.WriteLine("Updated product details:");
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }
}
