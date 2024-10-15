using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Repositories
{
    public class ProductRepository
    {
        // declare field to store collection of products
        private List<Product> _products;

        public ProductRepository(List<Product> products)
        {
            // Initialize the collection field
            _products = products;

        }

        /*
         * this method should accept product data and add it to the product collection
         * 
         */
        public void AddProduct(Product product)
        {
            if (product != null)
            {
                _products.Add(product);
            }
            else
            {
                Console.WriteLine("Product cannot be null.");
            }
        }


        /*
         * this method should search for the product by the provided product id 
         * and if found should remove it from the collection
         * 
         * the method should return true for success and false for invalid id 
         */
        public bool RemoveProduct(int productId)
        {
            var product = _products.Find(p => p.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
                return true;
            }
            return false;
        }


        /*
         * this method should search and return product by product name from the collection 
         * 
         * the search value should be passed as parameter
         * 
         * the method should return null for non-matching product name
         */
        public Product GetProduct(string productName)
        {
            var product = _products.Find(p => p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                Console.WriteLine("Product Cannot be Null");
            }
            return product;
        }

        /*
         * this method should search and return product by product id from the collection 
         * 
         * the search value should be passed as parameter
         * 
         * the method should return null for non-matching product id
         */
        public Product GetProduct(int productId)
        {
            var product = _products.Find(p => p.ProductId == productId);
            if (product == null)
            {
                Console.WriteLine("Product cannot be null.");
            }
            return product;

        }



        /*
         * this method should return all items from the product collection
         * 
         */
        public List<Product> GetAllProducts()
        {
            return _products;
        }
    }
}
