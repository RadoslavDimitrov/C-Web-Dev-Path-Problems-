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
        private static StringBuilder sb = new StringBuilder();
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //Problem 2
            //var input = Console.ReadLine();
            //string output = GetBooksByAgeRestriction(db, input);

            //Console.WriteLine(output);


            //Problem 3
            //Console.WriteLine(GetGoldenBooks(db));


            //Problem 4
            //Console.WriteLine(GetBooksByPrice(db));

            //Problem 5
            //int year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db,year));

            //Problem 6
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(db, input));

            string date = Console.ReadLine();
            Console.WriteLine(GetBooksReleasedBefore(db, date));
        }

        //Problem 7. Released Before Date

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            sb = new StringBuilder();

            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                });

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }

        //Problem 6 Book Titles by Category

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToLower()).ToList();

            List<string> bookTitles = new List<string>();

            foreach (var category in categories)
            {
                var currCategoryBooks = context.Books
                    .Where(b => b.BookCategories.Any(bc => bc.Category.Name.ToLower() == category))
                    .Select(b => b.Title)
                    .ToList();

                bookTitles.AddRange(currCategoryBooks);
            }

            return string.Join(Environment.NewLine, bookTitles.OrderBy(b => b));
        }

        //Problem 5. Not Released In

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //Problem 4 -Books by Price

        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context
                .Books
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - " +
                              $"${book.Price:f2}");
            }


            return sb.ToString().Trim();
        }

        //Problem 3 -Golden Books

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .AsEnumerable()
                .Where(b => b.EditionType.ToString() == "Gold")
                .Where(b => b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //Problem 2 - Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context.Books
                .AsEnumerable()
                .Where(b => b.AgeRestriction.
                    ToString().ToLower() == command.ToLower())
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }
    }
}
