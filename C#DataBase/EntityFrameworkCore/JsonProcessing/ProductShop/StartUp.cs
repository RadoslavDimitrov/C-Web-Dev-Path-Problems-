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
            //string input = File.ReadAllText("users.json");

            //string result = ImportUsers()
        }

        //public static string ImportUsers(ProductShopContext context, string inputJson)
        //{
        //    List<User> users = JsonConvert.DeserializeObject<List<User>>(inputJson);

        //    context.Users.AddRange(users);

        //    int count = users.Count;

        //    context.SaveChanges();

        //    return $"Successfully imported {count}";
        //}
    }
}