using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Menu
    {
        private BookShop shop;

        public Menu(BookShop bookShop)
        {
            shop = bookShop;
        }
        public void DisplayMenu()
        {
            bool exit = false;

            while (!exit)
            {
               
                Console.WriteLine("1. Filter by BookCode");
                Console.WriteLine("2. Filter by Price Range");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {

                        case 1:
                            // Filter by BookCode
                            Console.Write("Enter the BookCode to search: ");
                            string inputBookCode = Console.ReadLine();
                            Book filteredBook = shop.GetBookByCode(inputBookCode);

                            shop.DisplayBook(filteredBook);
                            break;

                        case 2:
                            // Filter by Price Range
                            Console.Write("Enter the minimum price: ");
                            decimal minPrice = Convert.ToDecimal(Console.ReadLine());
                            Console.Write("Enter the maximum price: ");
                            decimal maxPrice = Convert.ToDecimal(Console.ReadLine());

                            IEnumerable<Book> booksInRange = shop.GetBooksByPriceRange(minPrice, maxPrice);
                            shop.DisplayBooks(booksInRange);
                            break;


                        case 3:
                            // Exit
                            exit = true;
                            Console.WriteLine("Exiting the program.");
                            break;

                        default:
                            // Invalid Option
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
         
    }
}
