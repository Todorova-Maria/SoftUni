using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
namespace IteratorsAndComparators
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.Add(new Book("Animal Farm", 2003, "George Orwell"));
            library.Add(new Book("The Documents in the Case", 2003, "Dorothy Sayers", "Robert Eustace"));
            library.Add(new Book("The Documents in the Case", 1930, "-"));

            foreach (var book in library)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}