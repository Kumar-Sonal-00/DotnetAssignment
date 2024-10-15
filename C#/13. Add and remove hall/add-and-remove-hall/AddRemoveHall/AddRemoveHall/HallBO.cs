using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddRemoveHall
{
    internal class HallBO
    {
        public Hall CreateHall(string hallDetails)
        {
            string[] details = hallDetails.Split(',');
            string name = details[0];
            string contactNumber = details[1];
            double costPerDay = double.Parse(details[2]);
            string ownerName = details[3];

            Hall hall = new Hall(name, contactNumber, costPerDay, ownerName);
            return hall;
        }
        public bool RemoveHallFromList(List<Hall> hallList, int index)
        {
            if (index > 0 && index <= hallList.Count)
            {
                hallList.RemoveAt(index - 1);

                if (hallList.Count == 0)
                {
                    Console.WriteLine("Hall list empty");
                }
                else
                {
                    DisplayHalls(hallList);
                }

                return true;
            }
            return false;
        }
        public void DisplayHalls(List<Hall> hallList)
        {
            Console.WriteLine("{0}{1,15}{2,15}{3,15}", "Name", "Contact Number", "Cost per day", "Owner Name");

            foreach (Hall hall in hallList)
            {
                Console.WriteLine("{0}{1,15}{2,15}{3,15}", hall.Name, hall.ContactNumber, hall.CostPerDay, hall.OwnerName);
            }

        }
    }
}
