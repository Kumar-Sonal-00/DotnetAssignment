namespace SortProductCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
        {
            new Product(200, "Dell", "15 inch Monitor", 3400.44),
            new Product(120, "Dell", "Laptop", 45000.00),
            new Product(150, "Microsoft", "Windows 7", 7000.50),
            new Product(100, "Logitech", "Optical Mouse", 540.00)
        };
            Console.WriteLine("Products sorted by Product ID (default):");
            var sortedById = products.OrderBy(p => p.ProductID).ToList();
            foreach (var product in sortedById)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("\nEnter 1 to sort by Brand Name or 2 to sort by Price:");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Products sorted by Brand Name:");
                var sortedByBrand = products.OrderBy(p => p.BrandName).ToList();
                foreach (var product in sortedByBrand)
                {
                    Console.WriteLine(product);
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine("Products sorted by Price:");
                var sortedByPrice = products.OrderBy(p => p.Price).ToList();
                foreach (var product in sortedByPrice)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}
