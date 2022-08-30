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
            List<Book> books = new List<Book>()
            {
            (new Book("Animal Farm", 2003, "George Orwell")),
            (new Book("The Documents in the Case", 2003, "Dorothy Sayers", "Robert Eustace")),
            (new Book("The Documents in the Case", 1930, "-")),
            };
            books.Sort(new BookComparator());
            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}