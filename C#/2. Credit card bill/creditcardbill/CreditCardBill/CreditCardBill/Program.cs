namespace CreditCardBill
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = 1000.0;
            double monthlyInterestRate = 0.015;
            double totalPayments = 0.0;
            double monthlyPayment;

            Console.Write("Enter the monthly payment: ");
            if (!double.TryParse(Console.ReadLine(), out monthlyPayment) || monthlyPayment <= 0)
            {
                Console.WriteLine("Invalid input, Please enter a positive number.");
                return;
            }

            int month = 1;
            while (balance > 0)
            {
                balance = balance + (balance * monthlyInterestRate) - monthlyPayment;
                totalPayments += monthlyPayment;

                if (balance < 0) balance = 0;

                string output = String.Format(
                 "Month: {0} balance: {1:F4} total payments: {2:F4}",
                 month, balance, totalPayments);
                Console.WriteLine(output);
                month++;
            }
        }
    }
}
