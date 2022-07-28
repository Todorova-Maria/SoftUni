using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        int digit = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split();

        Func<string, int, bool> nameLength = (name, digit) => name.Length <= digit;

        string[] result = names.Where(name => nameLength(name, digit)).ToArray(); 

        foreach (var name in result)
        {
            Console.WriteLine(name);
        }
    }
}