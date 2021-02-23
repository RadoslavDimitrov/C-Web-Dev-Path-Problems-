using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;
using System;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SalesContext();

            var sale = new Sale()
            {
                CustomerId = 1,
                ProductId = 1,
                StoreId = 1
            };

            context.Add(sale);
            context.SaveChanges();
        }
    }
}
