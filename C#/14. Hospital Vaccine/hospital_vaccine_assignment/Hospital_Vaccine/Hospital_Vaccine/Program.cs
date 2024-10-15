namespace Hospital_Vaccine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HospitalManager hospitalManager = new HospitalManager();

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Enter hospital name to check vaccine availability");
                Console.WriteLine("2. Exit");
                Console.Write("Your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter hospital name: ");
                        string hospitalName = Console.ReadLine();
                        hospitalManager.CheckVaccineAvailability(hospitalName);
                        break;

                    case "2":
                        Console.WriteLine("Exiting the program...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            
        }
        }
    }
}
