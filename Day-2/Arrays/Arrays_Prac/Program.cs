using System;
using System.Collections.Generic;
using System.Linq;
namespace Arrays_Prac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To find the sum of the array");
            Console.WriteLine("Enter the size of the array");
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];
            Console.WriteLine("Enter the elements");
            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine("sum will be" + sum);
            Console.WriteLine("avg will be");
            double avg = (double)sum / size;
            Console.WriteLine(avg);
            Console.WriteLine("Max element");
            int max = arr[0];
            for (int i = 1; i < size; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            Console.WriteLine("Max: " + max);

            Console.WriteLine("Enter the element to search");
            int search = int.Parse(Console.ReadLine());
            bool found = false;

            for (int i = 0; i < size; i++)
            {
                if (arr[i] == search)
                {
                    found = true;
                    Console.WriteLine("Element found at index: " + i);
                    break;
                }

            }
            if (!found)
            {
                Console.WriteLine("not found");
            }

            //jagged arrays:
            int[][] jagged = new int[3][];
            jagged[0] = new int[] { 1, 2 };
            jagged[1] = new int[] { 3, 4, 5 };
            Console.WriteLine("Jagged array elements:");
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}