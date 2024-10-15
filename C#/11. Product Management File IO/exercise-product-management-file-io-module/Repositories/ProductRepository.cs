using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class ProductRepository
    {
        // declare field of type DataContext
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            //initialize the DataContext field with parameter passed    
            this._context = context;

        }

        /*
         * this method should accept product data and add it to the product collection
         * 
         */
        public void AddProduct(Product product)
        {
            // code to add product to file, ensuring that product is not null
            if (product != null)
            {
                _context.AddProduct(product);
                _context.SaveChanges();
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
            // code to remove product by the id provided from file as parameter
             Product product = _context.ReadProducts().Find(p => p.ProductId == productId);
            if (product != null)
            {
                _context.ReadProducts().Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        /*
         * this method should search and return product by product name from the file 
         * 
         * the search value should be passed as parameter
         * 
         * the method should return null for non-matching product name
         */
        public Product GetProduct(int productId)
        {
            return _context.ReadProducts().Find(p => p.ProductId == productId);
        }

        /*
         * this method should search and return product by product id from the collection 
         * 
         * the search value should be passed as parameter
         * 
         * the method should return null for non-matching product id
         */
        public Product GetProduct(string productName)
        {
            return _context.ReadProducts().Find(p => p.ProductName == productName);
        }


        /*
         * this method should return all items from the product collection
         */
        public List<Product> GetAllProducts()
        {
            return _context.ReadProducts();
        }
    }
}
