using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static string ResultsDirectoryPath = "../../../Datasets/Results";
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();


            //Problem 2
            string input = File.ReadAllText("../../../Datasets/products.json");

            string result = ImportProducts(context, input);

            Console.WriteLine(result);

            //Problem 1
            //string input = File.ReadAllText("../../../Datasets/users.json");

            //string result = ImportUsers(context, input);

            //Console.WriteLine(result);
        }

        //Problem 3


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
    }
}