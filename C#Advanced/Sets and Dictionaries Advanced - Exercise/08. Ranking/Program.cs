using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> exams = new Dictionary<string, string>();

            string command = Console.ReadLine();

            //data for the exams
            while (command != "end of contests")
            {
                command = GetExamData(exams, command);
            }
            //student name => exam, points
            Dictionary<string, Dictionary<string, int>> studentData = new Dictionary<string, Dictionary<string, int>>();

            //data for ppl joined the exams
            string submission = Console.ReadLine();

            while (submission != "end of submissions")
            {
                string[] currSubmission = submission.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string currContest = currSubmission[0];
                string currPass = currSubmission[1];
                string currUser = currSubmission[2];
                int currPoints = int.Parse(currSubmission[3]);

                if (exams.ContainsKey(currContest)) //valid contest
                {
                    if (exams[currContest] == currPass) //correct pass
                    {
                        if (!studentData.ContainsKey(currUser)) //new user
                        {
                            studentData.Add(currUser, new Dictionary<string, int>());
                            studentData[currUser].Add(currContest, currPoints);
                        }
                        else //user exist
                        {
                            UpdateExistingUserData(studentData, currContest, currUser, currPoints);
                        }
                    }
                    else //invalid pass
                    {
                        submission = Console.ReadLine();
                        continue;
                    }
                }
                else //invalid contest
                {
                    submission = Console.ReadLine();
                    continue;
                }


                submission = Console.ReadLine();
            }

            //"Best candidate is {user} with total {total points} points.

            GetAndPrintBestUser(studentData);
            studentData = SortAndPrintAllUsers(studentData);

        }

        private static Dictionary<string, Dictionary<string, int>> SortAndPrintAllUsers(Dictionary<string, Dictionary<string, int>> studentData)
        {
            Console.WriteLine("Ranking: ");
            studentData = studentData.OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value.OrderByDescending(y => y.Value).ToDictionary(y => y.Key, y => y.Value));

            foreach (var item in studentData)
            {
                Console.WriteLine(item.Key);

                foreach (var user in item.Value)
                {
                    Console.WriteLine($"#  {user.Key} -> {user.Value}");
                }
            }

            return studentData;
        }

        private static void UpdateExistingUserData(Dictionary<string, Dictionary<string, int>> studentData, string currContest, string currUser, int currPoints)
        {
            if (!studentData[currUser].ContainsKey(currContest)) //new exam for the user
            {
                studentData[currUser].Add(currContest, currPoints);
            }
            else //check for higher points
            {
                if (studentData[currUser][currContest] < currPoints) //new higher points
                {
                    studentData[currUser][currContest] = currPoints;
                }
            }
        }

        private static string GetExamData(Dictionary<string, string> exams, string command)
        {
            string[] currCommand = command.Split(":", StringSplitOptions.RemoveEmptyEntries);

            string contest = currCommand[0];
            string password = currCommand[1];

            if (!exams.ContainsKey(contest))
            {
                exams.Add(contest, password);
            }

            command = Console.ReadLine();
            return command;
        }

        private static void GetAndPrintBestUser(Dictionary<string, Dictionary<string, int>> studentData)
        {
            Dictionary<string, int> bestPoints = new Dictionary<string, int>();

            foreach (var item in studentData)
            {
                if (!bestPoints.ContainsKey(item.Key))
                {
                    bestPoints.Add(item.Key, 0);
                }
            }

            foreach (var item in studentData)
            {
                foreach (var points in item.Value)
                {
                    if (bestPoints.ContainsKey(item.Key))
                    {
                        bestPoints[item.Key] += points.Value;
                    }
                }
            }

            string bestUser = string.Empty;
            int bestUserPoint = -1;

            foreach (var item in bestPoints)
            {
                if (item.Value > bestUserPoint)
                {
                    bestUser = item.Key;
                    bestUserPoint = item.Value;
                }
            }

            Console.WriteLine($"Best candidate is {bestUser} with total {bestUserPoint} points.");
        }
    }
}
