using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        List<string> names = Console.ReadLine().Split().ToList();
        string text = Console.ReadLine();

        while (text != "Party!")
        {
            string[] command = text.Split();

            Predicate<string> predicate = GetPredicate(command[1], command[2]);

            if (command[0] == "Remove")
            {
                names.RemoveAll(predicate);
            }
            else if (command[0] == "Double")
            {
                List<string> doubledNames = names.FindAll(predicate);
                if (doubledNames.Any())
                {
                    foreach (var name in doubledNames)
                    {
                        int index = names.IndexOf(name);
                        names.Insert(index, name);                          
                    }
                }
            }
            text = Console.ReadLine();
        }
        if (names.Count > 0)
        {

            Console.WriteLine(String.Join(", ", names) + " are going to the party!");
        }
        else
        {
            Console.WriteLine("Nobody is going to the party!");
        }

    }

    private static Predicate<string> GetPredicate(string command, string parameter)
    {
        if (command == "StartsWith")
        {
            return x => x.StartsWith(parameter);
        }
        else if (command == "EndsWith")
        {
            return x => x.EndsWith(parameter);
        }
        int length = int.Parse(parameter);
        return x => x.Length == length;
    }
}