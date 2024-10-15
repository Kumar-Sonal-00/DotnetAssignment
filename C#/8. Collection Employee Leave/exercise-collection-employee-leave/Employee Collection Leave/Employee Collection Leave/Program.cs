namespace Employee_Collection_Leave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
        {
            new Employee(201, "Kumar Sonal", 111, 12),
            new Employee(202, "Abhijeet Acharaya", 112, 11),
            new Employee(203, "Aditya Prakash", 113, 7),
            new Employee(204, "Harsh Verdhan", 114, 6),
            new Employee(205, "Prince Jha", 115, 9)
        };

            Console.Write("Enter Employee ID: ");
            int empId = int.Parse(Console.ReadLine());

            Console.Write("Enter Number of Leaves Requested: ");
            int requestedLeaves = int.Parse(Console.ReadLine());

            Employee employee = employees.Find(e => e.GetEmpId() == empId);

            if (employee != null)
            {
                Console.WriteLine($"EmpId: {employee.GetEmpId()}");
                Console.WriteLine($"EmpName: {employee.GetEmpName()}");
                Console.WriteLine($"DeptId: {employee.GetDeptId()}");
                Console.WriteLine($"LeavesAvailable: {employee.GetLeavesAvailable()}");
                Console.WriteLine($"Requested Leaves: {requestedLeaves}");

                if (employee.RequestedLeaves(requestedLeaves))
                {
                    Console.WriteLine("Status: Approved");
                }
                else
                {
                    Console.WriteLine("Status: Rejected");
                }
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }
}
