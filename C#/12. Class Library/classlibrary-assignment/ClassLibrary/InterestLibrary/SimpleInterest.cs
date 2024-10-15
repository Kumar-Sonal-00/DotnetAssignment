namespace InterestLibrary
{
    public class SimpleInterest : Interest
    {
        public double CalculateInterest(double principal, double rate, double years)
        {
            return (principal * rate * years) / 100;
        }
    }
}
