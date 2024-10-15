using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class BookShop
    {
        private List<Book> books;

        public BookShop()
        {
            // Initialize the book collection
            books = new List<Book>
        {
            new Book("ASPNA", "ASP.Net Professional", "Wrox", "Bill Evjen, Matt Gibbs", 750.00m),
            new Book("ASPNB", "Beginning ASP.Net", "TechMedia", "Dan Wahlin, Dave Reed", 545.00m),
            new Book("LNQA", "Learning LINQ", "APress", "Steve Eichert", 400.00m),
            new Book("CSPN", "C# Developers Guide", "Tata McGraw", "Dan Maharry", 675.00m)
        };
        }
        // Method to filter by BookCode
        public Book GetBookByCode(string bookCode)
        {
            return books.Where(b => b.GetBookCode().Equals(bookCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        // Method to filter by price range
        public IEnumerable<Book> GetBooksByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return books.Where(b => b.GetPrice() >= minPrice && b.GetPrice() <= maxPrice);
        }
       

        public void DisplayBook(Book book)
        {
            if (book != null)
            {
                Console.WriteLine(book.ToString());
            }
            else
            {
                Console.WriteLine("No book found.");
            }
        }

        public void DisplayBooks(IEnumerable<Book> booksToDisplay)
        {
            if (booksToDisplay.Any())
            {
                foreach (var book in booksToDisplay)
                {
                    Console.WriteLine(book.ToString());
                }
            }
            else
            {
                Console.WriteLine("No books found within the specified criteria.");
            }
        }


    }
}