using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
namespace RecursiveArraySum
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(Sum(arr, arr.Length - 1));
        }

        public static int Sum(int[] arr, int index)
        {
            if (index == 0)
            {
                return arr[0];
            }

            return arr[index] + Sum(arr, --index);
        }
    }
}