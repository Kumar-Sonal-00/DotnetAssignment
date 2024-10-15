namespace CI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double principal = 1000.0;
            double rate = 0.05;
            double target = 1000000.0;
            int years = 0;

            while (principal < target)
            {
                principal += principal * rate;
                years++;
            }

            Console.WriteLine($"With an initial deposit of Rs 1000.00 and a 5% annual compound interest rate, it will take {years} years to reach a million rupees.");

        }
    }
}
