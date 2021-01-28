using System;
using System.Collections.Generic;
using System.Text;

namespace P5ChangeTownNamesCasing
{
    public static class Queryes
    {
        public static string FindAllTownNames = "SELECT t.Name FROM Towns as t JOIN Countries as c ON c.Id = t.CountryCode WHERE c.Name = @countryName";

        public static string UpdateAllTownNames = "UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = (SELECT c.Id FROM Countries as c WHERE c.Name = @countryName)";
    }
}
