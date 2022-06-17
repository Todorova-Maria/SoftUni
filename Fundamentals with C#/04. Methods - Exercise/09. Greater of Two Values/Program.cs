using System;
using System.Globalization;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        if (input == "int")
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            Console.WriteLine(CompareInteger(first, second));
        }
        else if (input == "char")
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            Console.WriteLine(CompareInteger(first, second));
        }
        else if (input == "string")
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            Console.WriteLine(CompareInteger(first, second));
        }
    }
    static int CompareInteger (int first, int second)
    {
        int compare = first.CompareTo(second); 
        if (compare > 0)
        {
            return first;

        } else
        {
            return second; 
        }
    }
    static char CompareInteger(char first, char second)
    {
        int compare = first.CompareTo(second);
        if (compare > 0)
        {
            return first;

        }
        else
        {
            return second;
        }
    }
    static string CompareInteger(string first, string second)
    {
        int compare = first.CompareTo(second);
        if (compare > 0)
        {
            return first;

        }
        else
        {
            return second;
        }
    }
}