using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class PrivilegeCustomer : Customer
    {
        public PrivilegeCustomer(string name, string address, string mobileNumber, int age)
       : base(name, address, mobileNumber, age)
        {
        }

        public double GenerateBillAmount(int amount)
        {
            return amount * 0.70; // 30% discount
        }
    }
}
