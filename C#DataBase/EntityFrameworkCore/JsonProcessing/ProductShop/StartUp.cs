using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTO;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static string ResultPath = "../../../Datasets/Results";
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            InitializeMapper();

            //Problem 8
            var json = GetUsersWithProducts(context);
            EnsureDirectoryExists();
            File.WriteAllText(ResultPath + "/users-and-products.json", json);

            //Problem 7
            //var json = GetCategoriesByProductsCount(context);
            //EnsureDirectoryExists();
            //File.WriteAllText(ResultPath + "/categories-by-productsDTO.json", json);

            //Problem 6
            //var json = GetSoldProducts(context);
            //EnsureDirectoryExists();
            //File.WriteAllText(ResultPath + "/users-sold-products.json", json);

            //Problem 5
            //var json = GetProductsInRange(context);
            //EnsureDirectoryExists();
            //File.WriteAllText(ResultPath + "/products-in-range.json", json);


            //Problem 4
            //string input = File.ReadAllText("../../../Datasets/categories-products.json");
            //string result = ImportCategoryProducts(context, input);

            //Problem 3
            //string input = File.ReadAllText("../../../Datasets/categories.json");
            //string result = ImportCategories(context, input);

            //Problem 2
            //string input = File.ReadAllText("../../../Datasets/products.json");

            //string result = ImportProducts(context, input);


            //Problem 1
            //string input = File.ReadAllText("../../../Datasets/users.json");

            //string result = ImportUsers(context, input);

            //Console.WriteLine(result);

            //Reset And Seed Database
            //ResetDatabase(context);
            //string users = File.ReadAllText("../../../Datasets/users.json");
            //string products = File.ReadAllText("../../../Datasets/products.json");
            //string categories = File.ReadAllText("../../../Datasets/categories.json");
            //string categoriesProducts = File.ReadAllText("../../../Datasets/categories-products.json");
            //SeedDatabase(context, users, products, categories, categoriesProducts);
        }

        //Problem 8

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .ToList()
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                .Select(u => new UserSoldProductsDTO()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsWithCountDTO()
                    {
                        Count = u.ProductsSold.Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                        .ToList()
                        .Where(p => p.Buyer != null)
                            .Select(p => new ProductDTO()
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .ToList()
                    }
                })
                .ToList();
            //var users = context.Users
            //    .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
            //    .OrderByDescending(x => x.ProductsSold.Count(p => p.Buyer != null))
            //    .Select(x => new UserSoldProductsDTO
            //    {
            //        FirstName = x.FirstName,
            //        LastName = x.LastName,
            //        Age = x.Age,
            //        SoldProducts = new SoldProductsWithCountDTO()
            //        {
            //            Count = x.ProductsSold.Count(p => p.Buyer != null),
            //            Products = x.ProductsSold
            //                        .ToList()
            //                        .Where(p => p.Buyer != null)
            //                        .Select(p => new ProductDTO()
            //                        {
            //                            Name = p.Name,
            //                            Price = p.Price
            //                        })
            //                        .ToList()


            //        }
            //    })
            //    .ToList();

            var resultObj = new UsersAndProductsDTO()
            {
                Count = users.Count,
                Users = users
            };

            var result = JsonConvert.SerializeObject(resultObj, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return result;

        }

        //Problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .ProjectTo<CategoriesByProductsCountDTO>()
                .ToList();
            //.Select(x => new
            //{
            //    category = x.Name,
            //    productsCount = x.CategoryProducts.Count,
            //    averagePrice = x.CategoryProducts.Average(cp => cp.Product.Price).ToString("f2"),
            //    totalRevenue = x.CategoryProducts.Sum(cp => cp.Product.Price).ToString("f2")
            //});

            string result = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return result;
        }

        //Problem 6

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .Where(x => x.ProductsSold.Count > 0)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                //.Select(x => new 
                //{
                //    firstName = x.FirstName,
                //    lastName = x.LastName,
                //    soldProducts = x.ProductsSold
                //                    .Where(p => p.Buyer != null)
                //                    .Select(p => new 
                //                    {
                //                        name = p.Name,
                //                        price = p.Price,
                //                        buyerFirstName = p.Buyer.FirstName,
                //                        buyerLastName = p.Buyer.LastName
                //                    })
                //                    .ToList()
                //})
                .ProjectTo<UsersWithSoldProductsDTO>()
                .ToList();

            var result = JsonConvert.SerializeObject(users, Formatting.Indented);

            return result;
        }

        //Problem 5

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                //.Select(x => new
                //{
                //    name = x.Name,
                //    price = x.Price,
                //    seller = x.Seller.FirstName + " " + x.Seller.LastName
                //})    
                .ProjectTo<ProductsInRangeDTO>()
                .ToList();

            var result = JsonConvert.SerializeObject(products, Formatting.Indented);

            return result;
        }

        //Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            List<CategoryProduct> categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);

            int count = categoryProducts.Count;

            context.SaveChanges();

            return $"Successfully imported {count}";
        }

        //Problem 3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(x => x.Name != null)
                .ToList();

            context.Categories.AddRange(categories);

            int count = categories.Count;

            context.SaveChanges();

            return $"Successfully imported {count}";
        }

        //Problem 2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);

            int count = products.Count;

            context.SaveChanges();

            return $"Successfully imported {count}";
        }

        //problem 1
        public static string ImportUsers(ProductShopContext context, string inputjson)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(inputjson);

            context.Users.AddRange(users);

            int count = users.Count;

            context.SaveChanges();

            return $"Successfully imported {count}";
        }

        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
        }

        private static void SeedDatabase(ProductShopContext context, string inputUsersJson, string inputProductsJson
            , string InputCategoriesJson, string inputCategoriesProductsJson)
        {
            Console.WriteLine(ImportUsers(context, inputUsersJson));
            Console.WriteLine(ImportProducts(context, inputProductsJson));
            Console.WriteLine(ImportCategories(context, InputCategoriesJson));
            Console.WriteLine(ImportCategoryProducts(context, inputCategoriesProductsJson));
        }
        private static void ResetDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");

            context.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }

        private static void EnsureDirectoryExists()
        {
            if (!Directory.Exists(ResultPath))
            {
                Directory.CreateDirectory(ResultPath);
            }
        }
    }
}