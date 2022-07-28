using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        List<string> names = Console.ReadLine().Split().ToList();
        string text = Console.ReadLine();
        Dictionary<string, Predicate<string>> predicateDict = new Dictionary<string, Predicate<string>>();

        while (text != "Print")
        {
            string[] commands = text.Split(";");
            string key = commands[1] + "_" + commands[2];

            if (commands[0] == "Add filter")
            {
                Predicate<string> predicate = GetPredicate(commands[1], commands[2]);
                predicateDict.Add(key, predicate);

            }
            else if (commands[0] == "Remove filter")
            {
                predicateDict.Remove(key);
            }

            text = Console.ReadLine();
        }
        foreach (var (key, value) in predicateDict)
        {
            names.RemoveAll(value);
        }
        Console.WriteLine(String.Join(" ", names));


    }
    private static Predicate<string> GetPredicate(string filterType, string letter)
    {
        if (filterType == "Starts with")
        {
            return name => name.StartsWith(letter);
        }
        else if (filterType == "Ends with")
        {
            return name => name.EndsWith(letter);
        }
        else if (filterType == "Contains")
        {
            return name => name.Contains(letter);
        }
        int length = int.Parse(letter);
        return name => name.Length == length;
    }
}