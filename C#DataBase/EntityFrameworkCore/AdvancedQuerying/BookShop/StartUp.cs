namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;


    public class StartUp
    {
        private static StringBuilder sb = new StringBuilder();
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);


            //var input = Console.ReadLine();
            //string output = GetBooksByAgeRestriction(db, input);

            //Console.WriteLine(output);

            Console.WriteLine(GetGoldenBooks(db));

        }

        //Problem 4 -Books by Price

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
