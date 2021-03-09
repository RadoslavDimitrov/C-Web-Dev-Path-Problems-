using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using CarDealer.XmlHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private const string DatasetsPath = @"../../../Datasets/";
        private const string ResultPath = DatasetsPath + @"/Results/";
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //ResetDatabase(context);

            //var xmlSuppliers = File.ReadAllText(DatasetsPath + "suppliers.xml");
            //ImportSuppliers(context, xmlSuppliers);

            //var xmlParts = File.ReadAllText(DatasetsPath + "parts.xml");
            //ImportParts(context, xmlParts);

            //var xmlCars = File.ReadAllText(DatasetsPath + "cars.xml");
            //System.Console.WriteLine(ImportCars(context, xmlCars));

            //var xmlCustomers = File.ReadAllText(DatasetsPath + "customers.xml");
            //Console.WriteLine(ImportCustomers(context, xmlCustomers));

            //var xmlSales = File.ReadAllText(DatasetsPath + "sales.xml");
            //Console.WriteLine(ImportSales(context, xmlSales));

            var xml = GetLocalSuppliers(context);
            EnsureDirectoryExist();
            File.WriteAllText(ResultPath + "local-suppliers.xml", xml);
        }

        //Problem 8
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new ExportLocalSuppliersDto
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    PartsCount = x.Parts.Count.ToString()
                })
                .ToArray();

            const string rootAttribute = "suppliers";
            XmlSerializer serializer = new XmlSerializer(typeof(ExportLocalSuppliersDto[]), new XmlRootAttribute(rootAttribute));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            serializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().Trim();
        }

        //Problem 7

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make.ToLower() == "bmw")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new ExportCarsBmwDto
                {
                    Id = x.Id.ToString(),
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance.ToString()
                })
                .ToArray();

            const string rootAttribute = "cars";
            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarsBmwDto[]), new XmlRootAttribute(rootAttribute));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().Trim();
        }

        //Problem 6
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .Select(x => new ExportCarsWithDistanceDto()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToArray();

            const string rootAttribute = "cars";

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarsWithDistanceDto[]), new XmlRootAttribute(rootAttribute));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().Trim();
        }

        //Problem 5
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string rootAttribute = "Sales";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute(rootAttribute));

            var salesDtos = (ImportSaleDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Sale> sales = new List<Sale>();

            foreach (var dto in salesDtos)
            {
                if(context.Cars.Any(c => c.Id == dto.CarId))
                {
                    Sale sale = new Sale()
                    {
                        CarId = dto.CarId,
                        CustomerId = dto.CustomerId,
                        Discount = dto.Discount
                    };

                    sales.Add(sale);
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //Problem 4
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string rootAttribute = "Customers";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute(rootAttribute));

            var customerDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Customer> customers = new List<Customer>();

            foreach (var customerDto in customerDtos)
            {
                DateTime date;

                bool isValidDate = DateTime.TryParseExact(customerDto.BirthDate, "yyyy-MM-dd'T'HH:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                if (isValidDate)
                {
                    Customer customer = new Customer()
                    {
                        Name = customerDto.Name,
                        BirthDate = date,
                        IsYoungDriver = customerDto.IsYoungDriver
                    };
                    customers.Add(customer);
                }
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //Problem 3
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string rootAttribute = "Cars";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarsDto[]), new XmlRootAttribute(rootAttribute));

            ImportCarsDto[] carsDtos = (ImportCarsDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var cars = new List<Car>();
            var partCars = new List<PartCar>();

            foreach (var carDto in carsDtos)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance
                };

                var parts = carDto
                    .Parts
                    .Where(pc => context.Parts.Any(p => p.Id == pc.Id))
                    .Select(p => p.Id)
                    .Distinct();

                foreach (var part in parts)
                {
                    PartCar partCar = new PartCar()
                    {
                        PartId = part,
                        Car = car
                    };

                    partCars.Add(partCar);
                }

                cars.Add(car);

            }

            context.PartCars.AddRange(partCars);

            context.Cars.AddRange(cars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }


        //Problem 2
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string rootAttribute = "Parts";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute(rootAttribute));

            var partsDto = (ImportPartDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Part> parts = new List<Part>();

            foreach (var dto in partsDto)
            {
                if (context.Suppliers.Any(s => s.Id == dto.SupplierId))
                {
                    Part part = new Part()
                    {
                        Name = dto.Name,
                        Price = dto.Price,
                        Quantity = dto.Quantity,
                        SupplierId = dto.SupplierId
                    };

                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //Problem 1
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string rootAttribute = "Suppliers";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute(rootAttribute));

            var suppliersDto = (ImportSupplierDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Supplier> suppliers = new List<Supplier>();

            foreach (var dto in suppliersDto)
            {
                Supplier supplier = new Supplier
                {
                    Name = dto.Name,
                    IsImporter = dto.isImporter
                };

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        private static void ResetDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
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