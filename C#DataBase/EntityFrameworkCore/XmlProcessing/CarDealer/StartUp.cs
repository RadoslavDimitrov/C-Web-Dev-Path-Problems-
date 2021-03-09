using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using CarDealer.XmlHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private const string DatasetsPath = @"../../../Datasets/";
        private const string ResultPath = DatasetsPath + @"/Results";
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //ResetDatabase(context);

            //var xmlSuppliers = File.ReadAllText(DatasetsPath + "suppliers.xml");
            //ImportSuppliers(context, xmlSuppliers);

            var xmlParts = File.ReadAllText(DatasetsPath + "parts.xml");
            System.Console.WriteLine(ImportParts(context, xmlParts));
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
                if(context.Suppliers.Any(s => s.Id == dto.SupplierId))
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

        private void EnsureDirectoryExist()
        {
            if (!Directory.Exists(ResultPath))
            {
                Directory.CreateDirectory(ResultPath);
            }
        }
    }
}