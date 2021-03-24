namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var DepartmentsWithCells = JsonConvert.DeserializeObject<ImportDepartmentsWithCellsDto[]>(jsonString);

            List<Department> departments = new List<Department>();

            int cellCounter = 0;

            foreach (var item in DepartmentsWithCells)
            {

                if (!IsValid(item))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if(item.Cells.Length < 1)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department department = new Department();
                List<Cell> cells = new List<Cell>();

                department.Name = item.Name;

                var cellsDto = item.Cells;

                int invalidCellCounter = 0;

                foreach (var cellDto in cellsDto)
                {
                    if (!IsValid(cellDto))
                    {
                        sb.AppendLine("Invalid Data");
                        invalidCellCounter++;
                        break;
                    }

                    Cell cell = new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow,                       
                    };

                    cells.Add(cell);
                }

                if(invalidCellCounter > 0)
                {
                    continue;
                }

                foreach (var actualCell in cells)
                {
                    department.Cells.Add(actualCell);
                }

                departments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

           
            //{
            //    "Name": "",
            //    "Cells": [
            //      {
            //                    "CellNumber": 101,
            //                      "HasWindow": true
            //      },
            //      {
            //                    "CellNumber": 102,
            //                      "HasWindow": false
            //      }
            //    ]
            //  },

        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}