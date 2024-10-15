namespace AddRemoveHall
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hall> hallList = new List<Hall>();
            HallBO hallBO = new HallBO();

            while (true)
            {
                Console.WriteLine("1.Add Hall");
                Console.WriteLine("2.Remove Hall");
                Console.WriteLine("3.Exit");
                Console.Write("Enter the choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter hall detail: ");
                        string? hallDetails = Console.ReadLine();
                        Hall hall = hallBO.CreateHall(hallDetails);
                        hallList.Add(hall);
                        Console.WriteLine("Hall Created Successfully");
                        break;
                    case 2:
                        if (hallList.Count == 0)
                        {
                            Console.WriteLine("List is Empty");
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Total {hallList.Count} Halls");
                            Console.Write("Enter the index: ");
                            int index = int.Parse(Console.ReadLine());

                            if (hallBO.RemoveHallFromList(hallList, index))
                            {
                                if (hallList.Count == 0)
                                {
                                    Console.WriteLine("Hall list empty");
                                }
                            }
                        }
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
