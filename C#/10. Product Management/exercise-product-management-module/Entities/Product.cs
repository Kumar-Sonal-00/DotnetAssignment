using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    /*
     * this class models product data that includes product id, product name, price and in-stock status
     *
     */

    public class Product
    {
        /*
         * define properties for Product model attributes 
         * 
         */

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public bool InStock { get; set; }
        public Product() { }

        public Product(int productId, string productName, int  price, bool inStock)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            InStock = inStock;
        }
        public override string ToString()
        {
            return $"Product ID: {ProductId}, Name: {ProductName}, Price: {Price}, In Stock: {InStock}";
        }


    }
}
