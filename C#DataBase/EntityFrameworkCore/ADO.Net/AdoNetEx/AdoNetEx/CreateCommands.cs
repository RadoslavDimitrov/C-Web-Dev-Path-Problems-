using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNetEx
{
    public static class CreateCommands
    {
        public static string CreateDB()
        {
            return "CREATE DATABASE MinionsDB";
        }

        public static string CreateTableCountries()
        {
            return "CREATE TABLE Countries " +
                    "(Id INT PRIMARY KEY IDENTITY," +
                    "[Name] NVARCHAR(50) NOT NULL)";
        }

        public static string CreateTableTowns()
        {
            return "CREATE TABLE Towns" +
                    "(Id INT PRIMARY KEY IDENTITY," +
                    "Name NVARCHAR(50) NOT NULL," +
                    "CountryCode INT REFERENCES Countries(Id))";
        }

        public static string CreateTableMinions()
        {
            return "CREATE TABLE Minions" +
                    "(Id INT PRIMARY KEY IDENTITY," +
                    "Name NVARCHAR(50) NOT NULL," +
                    "Age INT NOT NULL," +
                    "TownId INT REFERENCES Towns(Id))";
        }

        public static string CreateTableEvilnessFactors()
        {
            return "CREATE TABLE EvilnessFactors" +
                    "(Id INT PRIMARY KEY IDENTITY," +
                    "Name NVARCHAR(50) NOT NULL)";
        }

        public static string CreateTableVillains()
        {
            return "CREATE TABLE Villains" +
                    "(Id INT PRIMARY KEY IDENTITY," +
                    "Name NVARCHAR(50) NOT NULL," +
                    "EvilnessFactorId INT REFERENCES EvilnessFactors(Id))";
        }

        public static string CreateTableMinionsVillains()
        {
            return "CREATE TABLE MinionsVillains" +
                    "(MinionId INT REFERENCES Minions(Id) NOT NULL," +
                    "VillainId INT REFERENCES VIllains(Id) NOT NULL," +
                    "PRIMARY KEY (MinionId, VillainId))";
        }
    }
}
