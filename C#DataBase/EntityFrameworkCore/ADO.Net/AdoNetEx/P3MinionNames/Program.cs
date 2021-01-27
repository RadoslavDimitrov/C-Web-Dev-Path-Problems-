using Microsoft.Data.SqlClient;
using System;

namespace P3MinionNames
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
                string @villainId = Console.ReadLine();

                string command = "SELECT *" +
                                "FROM Villains as v " +
                                "JOIN MinionsVillains as mv ON mv.VillainId = v.Id " +
                                "JOIN Minions as m ON mv.MinionId = m.Id " +
                                "WHERE v.id = " + @villainId  +
                                "ORDER BY m.Name ASC";

                //output -> Gru - 6
                SqlCommand sqlCommand = new SqlCommand(command, sqlCon);
                sqlCommand.Parameters.AddWithValue(@villainId);
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
