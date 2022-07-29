using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<string> names = Console.ReadLine().Split().ToList();
        Func<string, int, bool> funcNames = (name, num) => name.Sum(x => x) >= num;
        Func<List<string>, int, Func<string, int, bool>, string> desiredNames = (allNames, n, funcNames) =>
        allNames.FirstOrDefault(x => funcNames(x, n));

        string name = desiredNames(names, n, funcNames); 
        Console.WriteLine(name);

    }
}