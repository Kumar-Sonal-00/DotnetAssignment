namespace Product_Price_Updation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string inputFile = @"C:\Assignments\Product Price Updation\product_price_updation\products.txt";  // Path to the input file
            string outputFile = @"C:\Assignments\Product Price Updation\product_price_updation\products_updated_text.txt";  // Path to the output file
            

            var manager = new ProductManager(inputFile, outputFile);
            List<Product> products = manager.ReadProducts();

            foreach (var product in products)
            {
                product.UpdatePrice();
            }

            manager.WriteProducts(products);
            manager.DisplayUpdatedProducts(products);

            Console.WriteLine("Price update completed. Check products_updated.txt for updated records.");
        
    }
    }
}
