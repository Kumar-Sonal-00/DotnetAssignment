using System.Xml.Linq;

namespace CustomerFeedback
{
    public class Customer
    {
        double FeedbackRating { get; set; }
        string MobileNumber { get; set; }
        string Name { get; set; }

        public Customer(double FeedbackRating, string MobileNumber, string Name)
        {
            this.FeedbackRating = FeedbackRating;
            this.MobileNumber = MobileNumber;
            this.Name = Name;
        }
        public double GetFeedbackRating()
        {
            return FeedbackRating;
        }

        public string GetMobileNumber()
        {
            return MobileNumber;
        }

        public string GetName()
        {
            return Name;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            

            // Create an array of customer objects
            Customer[] customers = CreateCustomerArray();

            // Calculate and print the average feedback rating
            double averageFeedbackRating = CalculateAverageFeedbackRating(customers);

            // Display all feedback ratings
            Console.WriteLine("All feedback ratings:");
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{customer.GetName()}: {customer.GetFeedbackRating()} out of 5");
            }

            Console.WriteLine($"The average feedback rating is: {averageFeedbackRating:F2} out of 5");
        }


        public static Customer[] CreateCustomerArray()
        {
            Console.Write("Enter the number of customers: ");
            int n = int.Parse(Console.ReadLine());

            Customer[] customers = new Customer[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter details for customer {i + 1}:");

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Mobile Number: ");
                string mobileNumber = Console.ReadLine();

                Console.Write("Feedback Rating (out of 5): ");
                double feedbackRating = double.Parse(Console.ReadLine());

                customers[i] = new Customer(feedbackRating, mobileNumber, name);
            }

            return customers;
        }

        public static double CalculateAverageFeedbackRating(Customer[] customers)
        {
            double totalFeedbackRating = 0;
            foreach (Customer customer in customers)
            {
                totalFeedbackRating += customer.GetFeedbackRating();
            }

            return totalFeedbackRating / customers.Length;
        }

    }
}
