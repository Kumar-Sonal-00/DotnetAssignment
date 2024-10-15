namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookShop shop = new BookShop();
            Menu menu = new Menu(shop);
            menu.DisplayMenu();
        }
    }
}
