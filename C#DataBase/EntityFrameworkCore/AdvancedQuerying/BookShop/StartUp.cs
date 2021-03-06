﻿namespace BookShop
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
            DbInitializer.ResetDatabase(db);

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

            //Problem 7
            //string date = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(db, date));

            //Problem 8
            //string input = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

            //Problem 9
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBookTitlesContaining(db, input));

            //Problem10
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByAuthor(db,input));

            //Problem11
            //int length = int.Parse(Console.ReadLine());
            //Console.WriteLine(CountBooks(db, length));

            //Problem12
            //Console.WriteLine(CountCopiesByAuthor(db));

            //Problem13
            //Console.WriteLine(GetTotalProfitByCategory(db));

            //Problem14
            //Console.WriteLine(GetMostRecentBooks(db));

            //Problem15
            //IncreasePrices(db);

            //Problem16
            Console.WriteLine(RemoveBooks(db));
            //Console.WriteLine(db.Books.Count());
        }

        //Problem 16. Remove Books

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200);

            int removedCount = books.Count();

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return removedCount;
        }

        //Problem 15. Increase Prices

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //Problem 14. Most Recent Books

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    book = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Take(3)
                    .Select(b => new
                    {
                        b.Book.Title,
                        Year = b.Book.ReleaseDate.Value.Year
                    })
                })
                .OrderBy(c => c.Name)
                .ToList();

            sb = new StringBuilder();

            foreach (var categorie in categories)
            {
                sb.AppendLine($"--{categorie.Name}");

                foreach (var book in categorie.book)
                {
                    sb.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return sb.ToString().Trim();
        }

        //Problem 13. Profit by Category

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            sb = new StringBuilder();

            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks
                            .Select(cb => new
                            {
                                BookProfit = cb.Book.Price * cb.Book.Copies
                            })
                            .Sum(c => c.BookProfit)
                })
                .OrderByDescending(p => p.TotalProfit)
                .ThenBy(c => c.Name)
                .ToList();

            foreach (var categorie in categories)
            {
                sb.AppendLine($"{categorie.Name} ${categorie.TotalProfit:F2}");
            }

            return sb.ToString().Trim();
        }

        //Problem 12. Total Book Copies

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            sb = new StringBuilder();

            var authors = context.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    Count = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.Count)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName} - {author.Count}");
            }

            return sb.ToString().Trim();

        }

        //Problem 11. Count Books

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var bookCount = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return bookCount;
        }

        //Problem 10. Book Search by Author

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorName})");
            }

            return sb.ToString().Trim();
        }

        //Problem 9. Book Search

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().Trim();
        }

        //Problem 8. Author Search

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName}");
            }

            return sb.ToString().Trim();
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
