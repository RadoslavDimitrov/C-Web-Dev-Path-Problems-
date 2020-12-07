using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO;
using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IManagerController manager;

        public Engine(IManagerController manager, IReader reader, IWriter writer)
        {
            this.manager = manager;
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            while (true)
            {
                string input = reader.ReadLine();

                string[] inputArr = input.Split();

                string msg = string.Empty;


                try
                {
                    switch (inputArr[0].ToLower())
                    {
                        case "addplayer":
                            //AddPlayer {player type} {player username}
                            string type = inputArr[1];
                            string username = inputArr[2];
                            msg = manager.AddPlayer(type, username);
                            break;
                        case "addcard":
                            //AddCard {card type} {card name} 
                            string cardType = inputArr[1];
                            string name = inputArr[2];
                            msg = manager.AddCard(cardType, name);
                            break;
                        case "addplayercard":
                            //AddPlayerCard {username} {card name} 
                            string currUsername = inputArr[1];
                            string cardName = inputArr[2];
                            msg = manager.AddPlayerCard(currUsername, cardName);
                            break;
                        case "fight":
                            //Fight {attack user} {enemy user} 
                            string attacker = inputArr[1];
                            string enemy = inputArr[2];
                            msg = manager.Fight(attacker, enemy);
                            break;
                        case "report":
                            msg = manager.Report();
                            break;
                        case "exit":
                            Environment.Exit(0);
                            break;
                    }

                    writer.WriteLine(msg);
                }
                catch (Exception ex)
                {

                    writer.WriteLine(ex.Message);
                }
                
            }
        }
    }
}
