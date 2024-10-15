using InterestLibrary;
namespace ClassLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read input from the user
            Console.WriteLine("Enter principal amount:");
            double principal = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter rate of interest:");
            double rate = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter number of years:");
            double years = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter type of interest (SI for Simple Interest, CI for Compound Interest):");
            string interestType = Console.ReadLine().ToUpper();

            // Create an instance of InterestCalculatorService
            InterestCalculatorService calculatorService = new InterestCalculatorService();

            try
            {
                // Calculate the interest using the service
                double calculatedInterest = calculatorService.Calculate(interestType, principal, rate, years);

                // Output the result
                Console.WriteLine($"The calculated interest is: {calculatedInterest}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
