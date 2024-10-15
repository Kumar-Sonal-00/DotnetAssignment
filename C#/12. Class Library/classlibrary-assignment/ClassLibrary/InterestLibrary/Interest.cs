using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestLibrary
{
    internal interface Interest
    {
        double CalculateInterest(double principal, double rate, double years);
    }
}
