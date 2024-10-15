using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuiceShopEntities;
using JuiceShopDAL;
using System.Data.SqlClient;
using JuiceShopExceptions;

namespace JuiceShopBusinessManager
{  
    public class JuiceShopManager
    {
        // Instance of JuiceShopDAO to interact with the data layer
        private JuiceShopDAO juiceShopDAO;
        

        // Constructor to initialize the DAO object
        public JuiceShopManager()
        {
            juiceShopDAO = new JuiceShopDAO();
        }
        public List<Juice> JuiceCurrStock() 
        {
            //TODO
            // return null;

            try
            {
                // Get the list of juice flavors from the DAO
                return juiceShopDAO.GetJuiceFlavors();
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("An error occurred while retrieving the juice stock.", ex);
            }
        }

        public int JuicePurchasedTrack(JuicePurchased jp) 
        {
            //TODO           
            // return 0;

            try
            {
                // Validate the juice quantity
                if (jp.Quantity <= 0)
                {
                    throw new JuiceIdException("Invalid quantity, please check your input");
                }

                // Validate the juice ID
                if (!int.TryParse(jp.Juice_id, out int juiceId) || !IsValidJuiceId(juiceId))
                {
                    throw new JuiceIdException("Invalid juice id, please check your input");
                }

                // Process the purchase through the DAO and return the total cost
                return juiceShopDAO.PurchaseJuice(jp);
            }
            catch (JuiceIdException ex)
            {
                // Handle custom exception for invalid quantity
                Console.WriteLine(ex.Message);
                return 0;
            }
            
            catch (Exception ex)
            {
                // Handle any other exceptions
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                return 0;
            }
        }
        // Helper method to validate if the juice ID exists in the list
        private bool IsValidJuiceId(int juiceId)
        {
            // Retrieve all juices and check if the specified juice ID exists
            var allJuices = juiceShopDAO.GetJuiceFlavors();
            return allJuices.Any(j => j.JuiceId == juiceId);
        }
    }
}
