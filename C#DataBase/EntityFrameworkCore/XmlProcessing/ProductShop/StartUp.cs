using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XmlHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        private static string ResultPath = @"../../../Datasets/Results";
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            

            //Problem 8
            string xmlUsersAndProducts = GetUsersWithProducts(context);
            File.WriteAllText(ResultPath + "/users-and-products.xml", xmlUsersAndProducts);
        }

        //Problem 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            const string rootElement = "Users";



            var usersWithProducts = new UsersAndProductsDto()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any(p => p.Buyer != null)),
                Users = context.Users
                        .ToArray()
                        .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                        .OrderByDescending(u => u.ProductsSold.Count)
                        .Take(10)
                        .Select(u => new UserDto()
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Age = u.Age,
                            SoldProducts = new SoldProductsDto()
                            {
                                Count = u.ProductsSold.Count(p => p.Buyer != null),
                                Products = u.ProductsSold
                                    .ToArray()
                                    .Where(p => p.Buyer != null)
                                    .Select(x => new SoldProductDto()
                                    {
                                        Name = x.Name,
                                        Price = x.Price
                                    })
                                    .OrderByDescending(x => x.Price)
                                    .ToArray()
                            }
                        })
                        .ToArray()

            };

            var result = XmlConverter.Serialize(usersWithProducts, rootElement);

            return result;
        }

        //Problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string rootElement = "Categories";

            var categories = context.Categories
                .Select(x => new CategoryDto
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Select(p => p.Product.Price).Average(),
                    TotalRevenue = x.CategoryProducts.Select(p => p.Product.Price).Sum()
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            var result = XmlConverter.Serialize(categories, rootElement);

            return result;
        }

        //Problem 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            const string rootElement = "Users";

            var users = context.Users
                .Where(x => x.ProductsSold.Any(x => x.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new UsersWithSoldProductsDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                    .Where(p => p.Buyer != null)
                    .Select(p => new SoldProductDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .Take(5)
                .ToList();

            var result = XmlConverter.Serialize(users, rootElement);

            return result;
        }

        //Problem 5

        public static string GetProductsInRange(ProductShopContext context)
        {
            string rootElement = "Products";

            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .Select(x => new ProductsInRangeDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerFullName = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .ToArray();

            var result = XmlConverter.Serialize(products, rootElement);

            return result;
        }

        //Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            string rootElement = "CategoryProducts";

            var categoriesDto = XmlConverter.Deserializer<InsertCategoryProductDto>(inputXml, rootElement);

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var cpDto in categoriesDto)
            {
                if(context.Categories.Any(c => c.Id == cpDto.CategoryId) && context.Products.Any(p => p.Id == cpDto.ProductId))
                {
                    var categoryProduct = new CategoryProduct
                    {
                        ProductId = cpDto.ProductId,
                        CategoryId = cpDto.CategoryId
                    };

                    categoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Problem 3
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            string rootElement = "Categories";

            var categoryDto = XmlConverter.Deserializer<InsertCategoryDto>(inputXml, rootElement);

            List<Category> categories = categoryDto.Where
                (x => x.Name != null)
                .Select(x => new Category
                {
                    Name = x.Name
                })
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Problem 2

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var productRootAttribute = "Products";

            var productsDto = XmlConverter.Deserializer<InsertProductsDto>(inputXml, productRootAttribute);

            var products = productsDto.Select(x => new Product
            {
                Name = x.Name,
                Price = x.Price,
                BuyerId = x.BuyerId,
                SellerId = x.SellerId
            })
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //Problem 1

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var userAttribute = "Users";

            var users = XmlConverter.Deserializer<InsertUsersDto>(inputXml, userAttribute);

            List<User> usersAsObj = users.Select(x => new User
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age
            })
                .ToList();

            context.Users.AddRange(usersAsObj);
            context.SaveChanges();

            return $"Successfully imported {usersAsObj.Count}";
        }

        private static void EnsureDirectoryExist()
        {
            if (!Directory.Exists(ResultPath))
            {
                Directory.CreateDirectory(ResultPath);
            }
        }
    }
}