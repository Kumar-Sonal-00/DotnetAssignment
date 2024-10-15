using System;

namespace PhoneNumberValidator
{
    //Please do not change the signature of class methods
    public class PhoneNumberValidator
    {
        static void Main(string[] args)
        {
            string phoneNumber = GetInput();
            int validationResult = ValidatePhoneNumber(phoneNumber);
            DisplayResult(validationResult);
        }

        public static string GetInput()
        {
            // Get phone number as input
            Console.WriteLine("Enter the phone number:");
            return Console.ReadLine().Trim();
        }

        public static void DisplayResult(int result)
        {
            // Display status of phone number valid or invalid
            if (result == 1)
            {
                Console.WriteLine("The phone number is valid");
            }
            else if (result == 0)
            {
                Console.WriteLine("The phone number is invalid");
            }
            else if (result == -1)
            {
                Console.WriteLine("The input is null or empty");
            }
        }

        public static int ValidatePhoneNumber(string input)
        {
            // Validate phone number
            // For null or empty value, function should return -1
            if (string.IsNullOrEmpty(input))
            {
                return -1;
            }

            // Remove dashes and check if only digits are left
            string digitsOnly = new string(input.Where(char.IsDigit).ToArray());

            // For invalid phone number, function should return 0
            if (digitsOnly.Length != 10)
            {
                return 0;
            }

            // Check if input contains only numbers and dashes
            if (!input.All(c => char.IsDigit(c) || c == '-'))
            {
                return 0;
            }

            // For valid phone number, function should return 1
            return 1;
        }
    }
}