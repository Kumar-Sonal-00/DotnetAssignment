using Entities;
using Repositories;

namespace ProductModuleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
              * code here is not mandatory but will help 
              * to understand flow better
              */

            string filePath = @"C:\Assignments\Product Management File Io\exercise-product-management-file-io-module"; 
            string fileName = "products.dat";
            var context = new DataContext(fileName, filePath);
            var productRepos = new ProductRepository(context);
            
        }
    }
}