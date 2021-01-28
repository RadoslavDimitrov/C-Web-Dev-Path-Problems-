using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace P4AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            //"Minion:<Name><Age><TownName>"

            //"Villain<Name>"

            string conStr = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=True;";
            using SqlConnection sqlCon = new SqlConnection(conStr);

            sqlCon.Open();

            string[] minionInfo = Console.ReadLine().Split();

            string minName = minionInfo[1];
            int minAge = int.Parse(minionInfo[2]);
            string minTown = minionInfo[3];

            string[] vilNameInfo = Console.ReadLine().Split();

            string vilName = vilNameInfo[1];

            StringBuilder result = new StringBuilder();

            CHeckForMinionTown(sqlCon, minTown, result);

            CheckForVillain(sqlCon, vilName, result);

            InsertMinion(sqlCon, minName, minAge);

            InsertIntoMinionVillains(sqlCon, minName, vilName, result);

            Console.WriteLine(result.ToString().TrimEnd());
        }

        private static void InsertIntoMinionVillains(SqlConnection sqlCon, string minName, string vilName, StringBuilder result)
        {
            string getMinionIdQuery = "SELECT Id FROM Minions WHERE [Name] = @name";
            SqlCommand getMinionIdCom = new SqlCommand(getMinionIdQuery, sqlCon);

            getMinionIdCom.Parameters.AddWithValue("@name", minName);
            string minId = getMinionIdCom.ExecuteScalar()?.ToString();

            string getVillainIdQuery = "SELECT Id FROM Villains WHERE [Name] = @name";
            SqlCommand getVillainIdCom = new SqlCommand(getVillainIdQuery, sqlCon);

            getVillainIdCom.Parameters.AddWithValue("@name", vilName);
            string vilId = getVillainIdCom.ExecuteScalar()?.ToString();

            string minionVillainInsertQuery = "INSERT INTO MinionsVillains([MinionId],[VillainId])" +
                                                " VALUES (@minId, @vilId);";
            SqlCommand insertIntoMVCom = new SqlCommand(minionVillainInsertQuery, sqlCon);
            insertIntoMVCom.Parameters.AddWithValue("@minId", int.Parse(minId));
            insertIntoMVCom.Parameters.AddWithValue("@vilId", int.Parse(vilId));

            insertIntoMVCom.ExecuteNonQuery();

            result.AppendLine($"Successfully added {minName} to be minion of {vilName}.");
        }

        private static void InsertMinion(SqlConnection sqlCon, string minName, int minAge)
        {
            string minionInsert = "INSERT INTO Minions([Name],[Age]) VALUES ('@name', @age)";
            SqlCommand insertMinionCom = new SqlCommand(minionInsert, sqlCon);

            insertMinionCom.Parameters.AddWithValue("@name", minName);
            insertMinionCom.Parameters.AddWithValue("@age", minAge);

            insertMinionCom.ExecuteNonQuery();
        }

        private static void CHeckForMinionTown(SqlConnection sqlCon, string minTown, StringBuilder result)
        {
            string minionTownQuery = "SELECT [Name] FROM Towns WHERE[Name] = @townName";
            SqlCommand minionTownCommand = new SqlCommand(minionTownQuery, sqlCon);
            minionTownCommand.Parameters.AddWithValue("@townName", minTown);

            string minionTownInfo = minionTownCommand.ExecuteScalar()?.ToString();



            if (minionTownInfo == null)
            {
                InsertIntoTown(sqlCon, minTown);

                result.AppendLine($"Town {minTown} was added to the database.");
            }
        }

        private static void InsertIntoTown(SqlConnection sqlCon, string minTown)
        {
            string insertTownQuery = "INSERT INTO Towns([Name]) VALUES ('@townName')";
            SqlCommand insertTownCom = new SqlCommand(insertTownQuery, sqlCon);

            insertTownCom.Parameters.AddWithValue("@townName", minTown);
            insertTownCom.ExecuteNonQuery();
        }

        private static void CheckForVillain(SqlConnection sqlCon, string vilName, StringBuilder result)
        {
            string vilIdQuery = "SELECT Id FROM Villains WHERE [Name] = @vilName";
            SqlCommand vilIdCommand = new SqlCommand(vilIdQuery, sqlCon);

            vilIdCommand.Parameters.AddWithValue("@vilName", vilName);
            string vilId = vilIdCommand.ExecuteScalar()?.ToString();

            if (vilId == null)
            {
                InsertIntoVillains(sqlCon, vilName);

                result.AppendLine($"Villain {vilName} was added to the database.");
            }
        }

        private static void InsertIntoVillains(SqlConnection sqlCon, string vilName)
        {
            string insertIntoVillains = "INSERT INTO Villains([Name],[EvilnessFactorId]) " +
                                                        "VALUES ('@vilName', 'Evil')";
            var insertVilCom = new SqlCommand(insertIntoVillains, sqlCon);
            insertVilCom.Parameters.AddWithValue("@vilName", vilName);

            insertVilCom.ExecuteNonQuery();
        }
    }
}
