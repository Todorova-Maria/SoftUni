using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());

        int[] divNumbers = Console.ReadLine().Split().Select(int.Parse).Distinct().ToArray();

        int[] allNumbers = Enumerable.Range(1, number).ToArray();

        List <Predicate<int>> predicateList = new List<Predicate<int>>(); 

        foreach (var n in divNumbers)
        {
            predicateList.Add(x => x % n == 0);
        }

        foreach (var currentNum in allNumbers)
        {
            bool isDivisible = true; 

            foreach (var predicate in predicateList)
            {
                if (!predicate(currentNum))
                {
                    isDivisible = false;
                    break;
                }
            }
            if(isDivisible)
            {
                Console.Write(currentNum + " ");
            }
        }
    }
}
