using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuiceShopEntities;
using JuiceShopBusinessManager;
using JuiceShopExceptions;

namespace JuiceShopClient
{   
    class JuiceShopClient {

        static void Main(string[] args)
        {
            //TODO

            JuiceShopManager juiceShopManager = new JuiceShopManager();
            bool continueShopping = true;
            List<JuicePurchased> purchases = new List<JuicePurchased>();

            try
            {
                while (continueShopping)
                {
                    // Display all available juice flavors
                    DisplayJuiceFlavors(juiceShopManager);

                    // Ask the user for the juice ID and quantity to purchase
                    Console.Write("Enter the ID of the juice you want to buy: ");
                    int juiceId;
                    while (!int.TryParse(Console.ReadLine(), out juiceId))
                    {
                        Console.Write("Invalid input. Please enter a valid juice ID: ");
                    }

                    Console.Write("Enter the quantity you want to purchase: ");
                    int quantity;
                    while (!int.TryParse(Console.ReadLine(), out quantity))
                    {
                        Console.Write("Invalid input. Please enter a valid quantity: ");
                    }

                    // Create a JuicePurchased object
                    JuicePurchased juicePurchased = new JuicePurchased
                    {
                        Juice_id = juiceId.ToString(),
                        Quantity = quantity
                    };

                    // Attempt to purchase the juice
                    int purchaseAmount = juiceShopManager.JuicePurchasedTrack(juicePurchased);

                    if (purchaseAmount > 0)
                    {
                        // Add the purchase to the list of purchases
                        juicePurchased.Amount = purchaseAmount;
                        purchases.Add(juicePurchased);
                        Console.WriteLine($"Successfully purchased {quantity} of Juice ID {juiceId} for {purchaseAmount}.");
                    }

                    // Ask the user if they want to continue shopping
                    Console.Write("Do you want to continue buying? (y/n): ");
                    string response = Console.ReadLine().ToLower();

                    if (response != "y")
                    {
                        continueShopping = false;
                    }
                }

                // Display all purchase details
                DisplayPurchaseSummary(purchases);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }

            Console.WriteLine("Thank you for shopping with us!");
        }
        // Method to display available juice flavors
        static void DisplayJuiceFlavors(JuiceShopManager juiceShopManager)
        {
            List<Juice> juices = juiceShopManager.JuiceCurrStock();

            Console.WriteLine("Available Juice Flavors:");
            Console.WriteLine("Juice ID\tJuice Flavor\tPrice");
            foreach (var juice in juices)
            {
                Console.WriteLine($"{juice.JuiceId}\t\t{juice.JuiceFavor}\t\t{juice.Price}");
            }
        }
        // Method to display a summary of all purchases
        static void DisplayPurchaseSummary(List<JuicePurchased> purchases)
        {
            Console.WriteLine("\nPurchase Summary:");
            Console.WriteLine("Purchase No\tJuice ID\tQuantity\tAmount");

            int totalAmount = 0;
            int purchaseNo = 1;

            foreach (var purchase in purchases)
            {
                Console.WriteLine($"{purchaseNo}\t\t{purchase.Juice_id}\t\t{purchase.Quantity}\t\t{purchase.Amount}");
                totalAmount += purchase.Amount;
                purchaseNo++;
            }

            Console.WriteLine($"\nTotal Amount: {totalAmount}");
        }
    
    }
}
