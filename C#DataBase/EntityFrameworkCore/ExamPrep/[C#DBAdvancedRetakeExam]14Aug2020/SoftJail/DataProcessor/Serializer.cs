namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.Linq;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .ToArray()
                .Where(x => ids.Any(id => id == x.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(po => new
                    {
                        OfficerName = po.Officer.FullName,
                        Department = po.Officer.Department.Name
                    })
                        .OrderBy(x => x.OfficerName),
                    TotalOfficerSalary = x.PrisonerOfficers.Sum(x => x.Officer.Salary)
                })
                .ToArray()
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id);

            string result = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return result;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] prisonersNamesAsArr = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries);

            var prisoners = context.Prisoners
                .ToArray()
                .Where(x => prisonersNamesAsArr.Any(p => p == x.FullName))
                .Select(x => new ExportPrisonerWithMessageDto
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = x.Mails
                    .ToArray()
                    .Select(m => new ExportMessageDto()
                    {
                        Description = Reverse(m.Description)
                    })
                    .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var result = XmlConverter.Serialize(prisoners, "Prisoners");

            return result;

            //        < Prisoner >
            //          < Id > 3 </ Id >
            //          < Name > Binni Cornhill </ Name >
            //          < IncarcerationDate > 1967 - 04 - 29 </ IncarcerationDate >
            //          < EncryptedMessages >
            //              < Message >
            //                  < Description > !? sdnasuoht evif - ytnewt rof deksa uoy ro orez artxe na ereht sI </ Description >
            //              </ Message >
            //          </ EncryptedMessages >
            //         </ Prisoner >
        }

        private static string Reverse(string description)
        {
            char[] resultChar = description.ToCharArray();

            Array.Reverse(resultChar);

            return new string(resultChar);
        }
    }
}