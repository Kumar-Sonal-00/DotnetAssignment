using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Vaccine
{
    internal class HospitalManager
    {
        private Dictionary<string, Hospital> hospitals;

        public HospitalManager()
        {
            hospitals = new Dictionary<string, Hospital>(StringComparer.OrdinalIgnoreCase)
        {
            { "APOLLO", new Hospital("Apollo", 50) },
            { "FORTIS", new Hospital("Fortis", 100) },
            { "MANIPAL", new Hospital("Manipal", 150) },
            { "AIIMS", new Hospital("AIIMS", 0) }
        };
        }

        public void CheckVaccineAvailability(string hospitalName)
        {

            if (hospitals != null && hospitals.ContainsKey(hospitalName))
            {
                hospitals[hospitalName].DisplayAvailability();
            }
            else
            {
                Console.WriteLine("Hospital not found.");
            }
        }
    }
}
