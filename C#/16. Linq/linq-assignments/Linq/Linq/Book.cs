using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Book
    {
        private string BookCode;
        private string BookName;
        private string PublisherName;
        private string AuthorName;
        private decimal Price;

        public Book(string bookCode, string bookName, string publisher, string author, decimal price)
        {
            BookCode = bookCode;
            BookName = bookName;
            PublisherName = publisher;
            AuthorName = author;
            Price = price;
        }

        public string GetBookCode()
        {
            return BookCode;
        }

        public string GetTitle()
        {
            return BookName;
        }

        public string GetPublisher()
        {
            return PublisherName;
        }

        public string GetAuthor()
        {
            return AuthorName;
        }

        public decimal GetPrice()
        {
            return Price;
        }

        public override string ToString()
        {
            return $"\nBook Details:\n" +
                   $"Book Code  : {BookCode}\n" +
                   $"Title      : {BookName}\n" +
                   $"Publisher  : {PublisherName}\n" +
                   $"Author(s)  : {AuthorName}\n" +
                   $"Price      : {Price:C}\n";
        }

    }
}
