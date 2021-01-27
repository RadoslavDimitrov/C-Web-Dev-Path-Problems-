using Microsoft.Data.SqlClient;
using System;

namespace AdoNetEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectonString =
                   @"Server=.\SQLEXPRESS;Database=Master;Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectonString);

            sqlConnection.Open();

            using (sqlConnection)
            {
                string com = CreateCommands.CreateDB();
                SqlCommand command = new SqlCommand(com, sqlConnection);
                command.ExecuteNonQuery();
            }

            connectonString = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";
            sqlConnection = new SqlConnection(connectonString);

            sqlConnection.Open();

            using (sqlConnection)
            {
                string com = CreateCommands.CreateTableCountries();
                SqlCommand command = new SqlCommand(com, sqlConnection);
                command.ExecuteNonQuery();

                com = CreateCommands.CreateTableTowns();
                command = new SqlCommand(com, sqlConnection);
                command.ExecuteNonQuery();

                com = CreateCommands.CreateTableMinions();
                command = new SqlCommand(com, sqlConnection);
                command.ExecuteNonQuery();

                com = CreateCommands.CreateTableEvilnessFactors();
                command = new SqlCommand(com, sqlConnection);
                command.ExecuteNonQuery();

                com = CreateCommands.CreateTableVillains();
                command = new SqlCommand(com, sqlConnection);
                command.ExecuteNonQuery();

                com = CreateCommands.CreateTableMinionsVillains();
                command = new SqlCommand(com, sqlConnection);
                command.ExecuteNonQuery();

                com = InsertCommands.InsertIntoCountries();
                command = new SqlCommand(com, sqlConnection);
                command.ExecuteNonQuery();

                com = InsertCommands.InsertIntoTowns();
                command = new SqlCommand(com, sqlConnection);
                command.ExecuteNonQuery();

                com = InsertCommands.InsertIntoMinions();
                command = new SqlCommand(com, sqlConnection);
                command.ExecuteNonQuery();

                com = InsertCommands.InsertIntoEvilnessFactors();
                command = new SqlCommand(com, sqlConnection);
                command.ExecuteNonQuery();

                com = InsertCommands.InsertIntoVillains();
                command = new SqlCommand(com, sqlConnection);
                command.ExecuteNonQuery();

                com = InsertCommands.InsertIntoMinionsVillains();
                command = new SqlCommand(com, sqlConnection);
                command.ExecuteNonQuery();

            }
        }
    }
}
