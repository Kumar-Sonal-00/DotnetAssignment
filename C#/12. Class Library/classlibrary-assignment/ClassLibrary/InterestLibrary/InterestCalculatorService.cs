using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestLibrary
{
    public class InterestCalculatorService
    {
        public double Calculate(string interestType, double principal, double rate, double years)
        {
            Interest interest;

            if (interestType == "SI")
            {
                interest = new SimpleInterest();
            }
            else if (interestType == "CI")
            {
                interest = new CompoundInterest();
            }
            else
            {
                throw new ArgumentException("Invalid interest type.");
            }

            return interest.CalculateInterest(principal, rate, years);
        }
    }
}
