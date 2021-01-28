using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace P5ChangeTownNamesCasing
{
    class Program
    {
        private static string conStr = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=True;";
        private static SqlConnection sqlCon = new SqlConnection(conStr);

        static void Main(string[] args)
        {
            string country = Console.ReadLine();

            sqlCon.Open();

            using (sqlCon)
            {
                SqlCommand findCityNames = new SqlCommand(Queryes.UpdateAllTownNames, sqlCon);
                findCityNames.Parameters.AddWithValue("@countryName", country);

                int rowsAffected = findCityNames.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    Console.WriteLine($"{rowsAffected} town names were affected.");

                    SqlCommand printTownNames = new SqlCommand(Queryes.FindAllTownNames, sqlCon);
                    printTownNames.Parameters.AddWithValue("@countryName", country);

                    var reader = printTownNames.ExecuteReader();

                    List<string> townNames = new List<string>();

                    while (reader.Read())
                    {
                        townNames.Add((string)reader["Name"]);
                    }

                    Console.WriteLine(string.Join(" ", townNames));
                }
            }
        }
    }
}
