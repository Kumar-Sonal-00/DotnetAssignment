using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestLibrary
{
    internal class CompoundInterest : Interest
    {
        public double CalculateInterest(double principal, double rate, double years)
        {
            return principal * Math.Pow((1 + rate / 100), years) - principal;
        }
    }
}
