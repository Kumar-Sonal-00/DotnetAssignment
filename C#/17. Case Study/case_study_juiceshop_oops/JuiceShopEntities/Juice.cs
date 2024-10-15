using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuiceShopEntities
{
    public class Juice 
    {
        //TODO
        // Private fields
        private int juiceId;
        private string juiceFlavor;
        private int price;

        // Constructor to initialize properties
        public Juice(int juiceId, string juiceFlavor, int price)
        {
            this.juiceId = juiceId;
            this.juiceFlavor = juiceFlavor;
            this.price = price;
        }

        public int JuiceId
        {
            get { return juiceId; }
        }

        public string JuiceFavor
        {
            get { return juiceFlavor; }
        }

        public int Price
        {
            get { return price; }
        }
    }

    public class JuicePurchased 
    {
        //TODO

        // Private fields
        private int purchaseNo;
        private string juiceId;
        private int quantity;
        private int amount;

        // Public properties with getters and setters
        public int Purchase_no
        {
            get { return purchaseNo; }
            set { purchaseNo = value; }
        }

        public string Juice_id
        {
            get { return juiceId; }
            set { juiceId = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }    
}
