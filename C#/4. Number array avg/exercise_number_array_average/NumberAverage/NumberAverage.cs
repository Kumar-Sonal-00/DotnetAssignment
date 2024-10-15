using System;

namespace NumberAverage
{
    public class NumberAverage
    {
        static void Main(string[] args)
        {

            // get size of array
            Console.Write("Enter the size of the array: ");
            int size = Convert.ToInt32(Console.ReadLine());

            // declare array for the given size
            int[] numbers = new int[size];

            //get the values of the array from the user
            //Console.WriteLine("Enter value:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter value {i + 1}: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            //call FindAverage() method to calculate average and receive string response
            string result = FindAverage(numbers);

            //print the result
            Console.WriteLine(result);
        }

        //write here logic to calculate the average an array
        public static String FindAverage(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return "Array is Empty";
            }
            int sum = 0;
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    sum += numbers[i];
            //}
            foreach (int number in numbers) {
                if (number < 0)
                {
                    return "Negative values in array";
                }
                sum += number;
            }

            double average =(double) sum / numbers.Length;
            return $"The Average is: {average}";
        }
    }
}