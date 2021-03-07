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

            ////Problem 1
            //var usersImport = File.ReadAllText("../../../Datasets/users.xml");
            //ImportUsers(context, usersImport);


            ////Problem 2
            //var xmlInput = File.ReadAllText("../../../Datasets/products.xml");
            //var resultProduct = ImportProducts(context, xmlInput);
            //Console.WriteLine(resultProduct);


            ////Problem 3
            //var xmlCategory = File.ReadAllText("../../../Datasets/categories.xml");
            //var categoryResult = ImportCategories(context, xmlCategory);
            //Console.WriteLine(categoryResult);

            ////Problem 4
            //var xmlCategoryProduct = File.ReadAllText("../../../Datasets/categories-products.xml");
            //var categoryProductResult = ImportCategoryProducts(context, xmlCategoryProduct);
            //Console.WriteLine(categoryProductResult);

            //Problem 5
            EnsureDirectoryExist();
            string xmlProducts = GetProductsInRange(context);
            File.WriteAllText(ResultPath + "/products-in-range.xml", xmlProducts);
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