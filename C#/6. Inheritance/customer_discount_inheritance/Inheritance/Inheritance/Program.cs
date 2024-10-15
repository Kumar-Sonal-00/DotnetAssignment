namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1)Privilege Customer");
            Console.WriteLine("2)SeniorCitizen Customer");
            Console.WriteLine("Enter Customer Type");
            int customerType = int.Parse(Console.ReadLine());

            if (customerType == 1 || customerType == 2)
            {
                Console.WriteLine("Enter The Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter The Age");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter The Address");
                string address = Console.ReadLine();
                Console.WriteLine("Enter The Mobile Number");
                string mobileNumber = Console.ReadLine();
                Console.WriteLine("Enter The Purchased Amount");
                int purchasedAmount = int.Parse(Console.ReadLine());

                Customer customer;
                double finalAmount = 0;

                if (customerType == 1)
                {
                    customer = new PrivilegeCustomer(name, address, mobileNumber, age);
                    finalAmount = ((PrivilegeCustomer)customer).GenerateBillAmount(purchasedAmount);
                }
                else
                {
                    customer = new SeniorCitizenCustomer(name, address, mobileNumber, age);
                    finalAmount = ((SeniorCitizenCustomer)customer).GenerateBillAmount(purchasedAmount);
                }

                Console.WriteLine("Bill Details");
                customer.DisplayCustomer();
                Console.WriteLine($"Your bill amount is Rs {purchasedAmount:F1}. Your bill amount is discount under {(customerType == 1 ? "privilege" : "senior citizen")} customer");
                Console.WriteLine($"You have to pay Rs {finalAmount:F2}");
            }
            else
            {
                Console.WriteLine("Invalid Customer Type");
            }
        }
    }
}
