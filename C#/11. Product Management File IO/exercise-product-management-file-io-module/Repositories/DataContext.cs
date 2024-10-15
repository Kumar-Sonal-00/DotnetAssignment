using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;

namespace Repositories
{
    // this class provides functionalities to read and write product collection data with file

    public class DataContext
    {
        // declare field for filename with path
        // declare field for list of products

        private readonly string filePath;
        private List<Product> products;

        // the constructor should accept filename and path strings
        public DataContext(string filePath, string fileName)
        {
            // the constructor code should open file if it exists else create new

            // the code should read data from file if it contains any data

            // the data read should populate the list of products field

            // if no data is present an empty list should be created 

            // Ensure the directory exists
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            this.filePath = Path.Combine( fileName, filePath);
            if (File.Exists(this.filePath))
            {
                using (FileStream fs = new FileStream(this.filePath, FileMode.Open))
                {
                    if (fs.Length > 0)
                    {
                        products = JsonSerializer.Deserialize<List<Product>>(fs);
                    }
                    else
                    {
                        products = new List<Product>();
                    }
                }
            }
            else
            {
                products = new List<Product>();
            }

        }

        // this method should return the list of products read from file
        public List<Product> ReadProducts()
        {
            // return data of the product list
            return products;
        }

        // this method should add the product data passed as parameter to the list of products
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        // this method should write the data from list of products to file and make data persistent
        public void SaveChanges()
        {
           

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                JsonSerializer.Serialize(fs, products);
            }
        }

        // this method should delete the file if exists
        public void CleanUp()
        {
            

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
