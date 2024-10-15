using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inheritance
{
    internal class Customer
    {
        private string name;
        private string address;
        private string mobileNumber;
        private int age;

        public Customer(string name, string address, string mobileNumber, int age)
        {
            this.name = name;
            this.address = address;
            this.mobileNumber = mobileNumber;
            this.age = age;
        }

        public string Name
        {
            get { return name; }
        }

        public string Address
        {
            get { return address; }
        }

        public string MobileNumber
        {
            get { return mobileNumber; }
        }

        public int Age
        {
            get { return age; }
        }
        public void DisplayCustomer()
        {
            Console.WriteLine($"Name {name}");
            Console.WriteLine($"Mobile {mobileNumber}");
            Console.WriteLine($"Age {age}");
            Console.WriteLine($"Address {address}");
        }
    }
}
