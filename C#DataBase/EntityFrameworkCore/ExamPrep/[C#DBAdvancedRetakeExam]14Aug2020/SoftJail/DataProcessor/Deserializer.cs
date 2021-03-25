namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

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
            var PrisonersDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Prisoner> prisoners = new List<Prisoner>();

            foreach (var PrisonerDto in PrisonersDtos)
            {
                if (!IsValid(PrisonerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isInvalidMail = false;

                List<Mail> mails = new List<Mail>();

                foreach (var mailDto in PrisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        sb.AppendLine("Invalid Data");
                        isInvalidMail = true;
                        break;
                    }

                    Mail mail = new Mail()
                    {
                        Address = mailDto.Address,
                        Description = mailDto.Description,
                        Sender = mailDto.Sender
                    };

                    mails.Add(mail);
                }

                if (isInvalidMail)
                {
                    continue;
                }

                Prisoner prisoner = new Prisoner()
                {
                    FullName = PrisonerDto.FullName,
                    Age = PrisonerDto.Age,
                    Nickname = PrisonerDto.Nickname,
                    IncarcerationDate = DateTime.ParseExact(PrisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    CellId = PrisonerDto.CellId,
                    Bail = PrisonerDto.Bail,
                    Mails = mails
                };

                if(PrisonerDto.ReleaseDate != null)
                {
                    prisoner.ReleaseDate = DateTime.ParseExact(PrisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                prisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");

            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));

            //var reader = new StringReader(xmlString);

            //var dtos = (ImportOfficerDto[])xmlSerializer.Deserialize(reader);

            var dtos = XmlConverter.Deserializer<ImportOfficerDto>(xmlString, "Officers");

            List<Officer> officers = new List<Officer>();
            List<OfficerPrisoner> officerPrisoners = new List<OfficerPrisoner>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Position position;
                bool isValidPosition = Enum.TryParse(dto.Position, out position);
                if (!isValidPosition)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Weapon weapon;
                bool isValidWeapon = Enum.TryParse(dto.Weapon, out weapon);
                if (!isValidWeapon)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Officer officer = new Officer
                {
                    FullName = dto.Name,
                    Salary = dto.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = dto.DepartmentId
                };


                
                foreach (var prisonerDto in dto.Prisoners)
                { 

                    officer.OfficerPrisoners.Add(new OfficerPrisoner 
                    { 
                        Officer = officer,
                        PrisonerId = prisonerDto.PrisonerId 
                    });
                }

                officers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().Trim();
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