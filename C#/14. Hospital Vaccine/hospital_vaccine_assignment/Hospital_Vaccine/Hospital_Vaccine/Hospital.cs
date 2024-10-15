using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Vaccine
{
    internal class Hospital
    {
        public string Name { get; set; }
        public int AvailableVaccines { get; set; }

        public Hospital(string name, int availableVaccines)
        {
            Name = name;
            AvailableVaccines = availableVaccines;
        }

        public void DisplayAvailability()
        {
            if (AvailableVaccines > 0)
            {
                Console.WriteLine($"{Name} has {AvailableVaccines} vaccines available.");
            }
            else
            {
                Console.WriteLine("Slot full");
            }
        }
    }
}
