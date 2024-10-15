using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddRemoveHall
{
    internal class Hall
    {
        private string _name;
        private string _contactNumber;
        private double _costPerDay;
        private string _ownerName;

        // Constructor
        public Hall(string name, string contactNumber, double costPerDay, string ownerName)
        {
            _name = name;
            _contactNumber = contactNumber;
            _costPerDay = costPerDay;
            _ownerName = ownerName;
        }
        // Getters and Setters
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string ContactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; }
        }

        public double CostPerDay
        {
            get { return _costPerDay; }
            set { _costPerDay = value; }
        }
        public string OwnerName
        {
            get { return _ownerName; }
            set { _ownerName = value; }
        }
    }
}
