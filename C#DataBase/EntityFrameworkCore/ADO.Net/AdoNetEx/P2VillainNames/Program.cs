using Microsoft.Data.SqlClient;
using System;

namespace P2VillainNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=True;";
            SqlConnection sqlCon = new SqlConnection(conStr);

            sqlCon.Open();

            using (sqlCon)
            {
                string command = "SELECT v.Name," +
                    "COUNT(mv.VillainId) as MinionsCount " +
                    "FROM Villains as v " +
                    "JOIN MinionsVillains as mv ON mv.VillainId = v.Id " +
                    "GROUP BY v.Id,v.Name " +
                    "HAVING COUNT(mv.VillainId) > 3 " + 
                    "ORDER BY COUNT(mv.VillainId) ";

                //output -> Gru - 6
                using SqlCommand sqlCommand = new SqlCommand(command, sqlCon);
                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    int count = (int)reader["MinionsCount"];

                    Console.WriteLine($"{name} - {count}");
                }

            }
        }
    }
}
