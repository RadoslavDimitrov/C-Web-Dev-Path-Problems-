using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static string ResultPath = @"../../../Datasets/Results";
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            InitializeMapper();

            //ResetDatabase(context);


            //Problem 9
            //string supInput = File.ReadAllText("../../../Datasets/suppliers.json");
            //string resultSup = ImportSuppliers(context, supInput);
            //Console.WriteLine(resultSup);

            //Problem 10
            //string input = File.ReadAllText("../../../Datasets/parts.json");
            //string result = ImportParts(context, input);
            //Console.WriteLine(result);

            //Problem 11
            //string input = File.ReadAllText("../../../Datasets/cars.json");
            //string result = ImportCars(context, input);
            //Console.WriteLine(result);

            //Problem 12
            //string input = File.ReadAllText("../../../Datasets/customers.json");
            //string result = ImportCustomers(context, input);
            //Console.WriteLine(result);

            //Problem 13
            //string input = File.ReadAllText("../../../Datasets/sales.json");
            //string result = ImportSales(context, input);
            //Console.WriteLine(result);

            //Problem 14
            string json = GetOrderedCustomers(context);
            EnsureDirectoryExist();
            File.WriteAllText(ResultPath + "/ordered-customers.json", json);
        }

        //Problem 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new OrderedCustomerDto()
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            List<CarDto> carDtos = JsonConvert.DeserializeObject<List<CarDto>>(inputJson);

            List<Car> cars = new List<Car>();

            foreach (var carDto in carDtos)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var partId in carDto.PartsId.Distinct())
                {
                    car.PartCars.Add(new PartCar()
                    {
                        Car = car,
                        PartId = partId
                    });
                };

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";

        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);
            var suppliers = context.Suppliers.Select(s => s.Id);

            parts = parts.Where(p => suppliers.Any(s => s == p.SupplierId)).ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        //Problem 9

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        private static void EnsureDirectoryExist()
        {
            if (!Directory.Exists(ResultPath))
            {
                Directory.CreateDirectory(ResultPath);
            }
        }
        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
        }

        private static void ResetDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("Database was deleted");
            context.Database.EnsureCreated();
            Console.WriteLine("Database was created");
        }
    }
}