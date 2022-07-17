using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        SortedSet<string> elements = new SortedSet<string>();

        for (int i = 0; i < n; i++)
        {
            string[] chemicalElements = Console.ReadLine().Split();

            for (int j = 0; j < chemicalElements.Length; j++)
            {
                elements.Add(chemicalElements[j]); 
            }
           
        }
        Console.WriteLine(String.Join(" ", elements));
    }
}