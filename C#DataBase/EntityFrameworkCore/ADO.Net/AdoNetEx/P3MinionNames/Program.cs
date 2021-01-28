using Microsoft.Data.SqlClient;
using System;
using System.Text;

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
                StringBuilder result = new StringBuilder();

                int villainId = int.Parse(Console.ReadLine());

                string villainNameQuery = "SELECT [Name] FROM Villains WHERE Id = @villainId";
                SqlCommand villainCommand = new SqlCommand(villainNameQuery, sqlCon);
                villainCommand.Parameters.AddWithValue("@villainId", villainId);

                string vilName = villainCommand.ExecuteScalar()?.ToString();

                if(vilName == null)
                {
                    result.AppendLine($"No villain with ID {villainId} exists in the database.");
                }
                else
                {
                    result.AppendLine($"Villain: {vilName}");

                    string command = "SELECT " +
                                         "m.Name, " +
                                         "m.Age " +
                                "FROM Villains as v " +
                                "JOIN MinionsVillains as mv ON mv.VillainId = v.Id " +
                                "JOIN Minions as m ON mv.MinionId = m.Id " +
                                "WHERE v.id = @villainId " +
                                "ORDER BY m.Name ASC";

                    SqlCommand sqlCommand = new SqlCommand(command, sqlCon);
                    sqlCommand.Parameters.AddWithValue("@villainId", villainId);

                    var reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        int rowNum = 1;

                        while (reader.Read())
                        {
                            string minionName = reader["Name"].ToString();
                            string minionAge = reader["Age"].ToString();

                            result.AppendLine($"{rowNum}. {minionName} {minionAge}");

                            rowNum++;
                        }
                    }
                    else
                    {
                        result.AppendLine("(no minions)");
                    }
                }



                Console.WriteLine(result.ToString().TrimEnd());
                
            }
        }
    }
}