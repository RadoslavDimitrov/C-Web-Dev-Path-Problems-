using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace P7PrintAllMinionNames
{
    class Program
    {
        private static string conStr = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=True;";
        private static SqlConnection sqlCon = new SqlConnection(conStr);

        static void Main(string[] args)
        {
            sqlCon.Open();

            using (sqlCon)
            {
                SqlCommand getNamesCommand = new SqlCommand(Queryes.GetAllMinionNames, sqlCon);

                List<string> names = new List<string>();

                using (getNamesCommand)
                {
                    var reader = getNamesCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        names.Add((string)reader["Name"]);
                    }
                }

                if(names.Count % 2 == 0) //even
                { 
                    int first = 0;

                    while (first != names.Count / 2)
                    {
                        for (int last = names.Count - 1; last >= names.Count / 2; last--)
                        {
                            if (first == names.Count / 2)
                            {
                                break;
                            }

                            Console.WriteLine(names[first]);
                            Console.WriteLine(names[last]);
                            first++;
                           
                        }
                        

                    }
                }
                else
                {
                    int first = 0;

                    while (first < names.Count / 2)
                    {
                        for (int last = names.Count - 1; last > names.Count / 2; last--)
                        {
                            if (first > names.Count / 2)
                            {
                                break;
                            }

                            Console.WriteLine(names[first]);
                            Console.WriteLine(names[last]);
                            first++;
                            
                        }

                        Console.WriteLine(names[names.Count/2]);
                    }
                }
            }
        }
    }
}
