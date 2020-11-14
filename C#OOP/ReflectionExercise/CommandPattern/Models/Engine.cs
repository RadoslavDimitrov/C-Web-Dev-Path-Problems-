using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Models
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                string inputData = Console.ReadLine();
                string result = commandInterpreter.Read(inputData);
                Console.WriteLine(result);
            }
        }
    }
}
