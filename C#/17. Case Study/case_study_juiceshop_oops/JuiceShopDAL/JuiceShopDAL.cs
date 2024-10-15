using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuiceShopEntities;
using System.Data;
using System.Data.SqlClient;
using JuiceShopExceptions;

namespace JuiceShopDAL
{
    interface IDatabase 
    {    
        List<Juice> GetJuiceFlavors();
        int PurchaseJuice(JuicePurchased juicePurchased);
    }    
    public class JuiceShopDAO : IDatabase
    {
        List<Juice> lstJuice=new List<Juice>();
        List<JuicePurchased> lstJuicePurchased = new List<JuicePurchased>();
        private static int purchaseNoCounter = 1;
        public JuiceShopDAO() 
        {
            //TODO
            //add all the default Juice records manually as per given in doc file

            lstJuice = new List<Juice>
            {
                new Juice(1001, "Apple", 50),
                new Juice(1002, "Mango", 20),
                new Juice(1003, "Grapes", 30),
                new Juice(1004, "Banana", 20),
                new Juice(1005, "Orange", 70)
            };
            lstJuicePurchased = new List<JuicePurchased>();
        }
        public List<Juice> GetJuiceFlavors()
        {
            //TODO return all the juice records
            //return null;
            return lstJuice
                .OrderBy(j => j.Price)
                .ThenBy(j => j.JuiceFavor)
                .ToList();
        }
        public int PurchaseJuice(JuicePurchased juicePurchased)
        {
            //TODO -returns the cost of Juice Purchased
            //return price * quantity of juicePurchased;
            //return 0;

            var juice = lstJuice.FirstOrDefault(j => j.JuiceId.ToString() == juicePurchased.Juice_id);
            if (juice == null)
                throw new JuiceIdException("Invalid Juice ID");

            if (juicePurchased.Quantity <= 0)
                throw new JuiceIdException("Invalid quantity, please check your input");

            juicePurchased.Amount = juice.Price * juicePurchased.Quantity;
            juicePurchased.Purchase_no = purchaseNoCounter++;
            lstJuicePurchased.Add(juicePurchased);

            return juicePurchased.Amount;
        }
    }
}
