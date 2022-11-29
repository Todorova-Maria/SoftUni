namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static object CultuteInfo { get; private set; }

        public static void Main()
        {
            using var db = new BookShopContext();
            // DbInitializer.ResetDatabase(db);  



            RemoveBooks(db);


        }

        //Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            AgeRestriction ageRestriction;
            bool parseSuccess =
                Enum.TryParse<AgeRestriction>(command, true, out ageRestriction);

            if (!parseSuccess)
            {
                return String.Empty;
            }

            var booksWithAgeRestriction = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return String.Join(Environment.NewLine, booksWithAgeRestriction);

        }
        //Problem 03 
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, goldenBooks);

        }

        //Problem 04 
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price}");
            }
            return sb.ToString().TrimEnd();

        }

        //Problem 05 

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();


            return String.Join(Environment.NewLine, books);


        }

        //Problem 06
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToList();

            var books = context.BooksCategories
                .Where(x => categories.Contains(x.Category.Name.ToLower()))
                .Select(x => x.Book.Title)
                .OrderBy(title => title)
                .ToArray();

            var result = String.Join(Environment.NewLine, books);

            return result;

        }

        //Problem 07
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime dt = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books
                .Where(x => x.ReleaseDate < dt)
                .Select(x => new
                {
                    Title = x.Title,
                    EditionType = x.EditionType,
                    Price = x.Price,
                    Date = x.ReleaseDate
                })
                .OrderByDescending(x => x.Date)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //Problem 08  
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {

            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => $"{x.FirstName} {x.LastName}")
                .ToArray()
                .OrderBy(n => n)
                .ToArray();

            return String.Join(Environment.NewLine, authors);
        }

        //Problem 09  
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string inputIgnoreCasing = input.ToLower();

            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(inputIgnoreCasing))
                .Select(x => x.Title)
                .OrderBy(t => t)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        //Problem 10  
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder(); 

            string nameIgnoreCase = input.ToLower();
            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(nameIgnoreCase))
                .Select(x => new
                {
                    Title = x.Title,
                    FirstName = x.Author.FirstName,
                    LastName = x.Author.LastName,
                    BookId = x.BookId
                }) 
                .OrderBy(x=> x.BookId)
                .ToArray();

            foreach (var book in books ) 
            {
                sb.AppendLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 11 
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Select(x => x.Title)
                .Count();

            return books; 
        }

        //Problem 12 
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder(); 
            var authors = context.Authors
                .Select(x => new
                {
                    Name = x.FirstName + " " + x.LastName,
                    CountCopies = x.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.CountCopies)
                .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.Name} - {author.CountCopies}"); 
            }

            return sb.ToString().TrimEnd(); 
                
        }

        //Problem 13 

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder(); 
            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    TotalProfit = x.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies)
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.CategoryName)
                .ToArray();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.CategoryName} ${category.TotalProfit:f2}"); 
            }

            return sb.ToString().TrimEnd(); 
        }

        //Problem 14 
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder(); 
            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Books = x.CategoryBooks.Select(x => new
                    {
                        BookName = x.Book.Title,
                        ReleaseYear = x.Book.ReleaseDate
                    })
                    .OrderByDescending(x => x.ReleaseYear)
                    .Take(3)
                })
                .OrderBy(x => x.CategoryName)
                .ToArray();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.BookName} ({book.ReleaseYear.Value.Year})");
                }
            }
            return sb.ToString().TrimEnd(); 
        }

        //Problem 15 
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010);
                

            foreach (var b in books)
            {
                b.Price += 5;
            }
            context.SaveChanges();
                
        }


        //Problem 16 
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);
            context.SaveChanges();
            return books.Count;


        }
    }
}
