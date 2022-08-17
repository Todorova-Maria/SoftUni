using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
class Program
{
    static void Main(string[] args)
    {
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] sorted = nums.OrderByDescending(x => x).ToArray();

        List<int> bestNums = new List<int>();
        int count = 0;

        for (int i = 0; i < sorted.Length; i++)
        {
            if (count < 3)
            {
                bestNums.Add(sorted[i]);
                count++;
            }
        }
        if (count == 3)
        {
            Console.WriteLine(String.Join(" ", bestNums));
        }
        else
        {
            Console.WriteLine(String.Join(" ", sorted));
        }
    }
}