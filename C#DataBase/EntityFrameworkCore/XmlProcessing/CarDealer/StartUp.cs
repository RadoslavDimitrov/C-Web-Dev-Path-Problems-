using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using CarDealer.XmlHelper;
using System.Collections.Generic;
using System.IO;
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

            var xmlSuppliers = File.ReadAllText(DatasetsPath + "suppliers.xml");
            var result = ImportSuppliers(context, xmlSuppliers);
            System.Console.WriteLine(result);
        }

        //Problem 1
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Suppliers";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute(rootElement));

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