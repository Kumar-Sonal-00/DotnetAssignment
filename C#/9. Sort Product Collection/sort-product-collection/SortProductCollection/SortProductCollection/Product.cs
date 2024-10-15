using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortProductCollection
{
    internal class Product
    {
        private int productID;
        private string brandName;
        private string description;
        private double price;

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public string BrandName
        {
            get { return brandName; }
            set { brandName = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public double Price
        {

            get { return price; }
            set { price = value; }
        }
        public Product(int productID, string brandName, string description, double price)
        {
            this.productID = productID;
            this.brandName = brandName;
            this.description = description;
            this.price = price;
        }
        public override string ToString()
        {
            return $"ProductID: {productID}, BrandName :{brandName}, Description : {description}, Price : {price} ";
        }
    }
    
   
}
