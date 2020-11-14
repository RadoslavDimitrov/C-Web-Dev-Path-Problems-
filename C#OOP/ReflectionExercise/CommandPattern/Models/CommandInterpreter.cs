using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string commandPostfix = "Command";
        public string Read(string args)
        {
            string[] tokens = args.Split();

            //name
            string commandName = tokens[0];
            string commandTypeName = commandName + commandPostfix;

            Type commandType = Assembly.GetCallingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.Name == nameof(ICommand)))
                .FirstOrDefault(t => t.Name == commandTypeName);

            if (commandType == null)
            {
                throw new InvalidOperationException("Command type is invalid.");
            }

            ICommand command = Activator.CreateInstance(commandType) as ICommand;

            string[] clearData = tokens.Skip(1).ToArray();
            string result = command.Execute(clearData);

            return result;
        }





        //public string Read(string args)
        //{
        //    string[] tokens = args.Split();

        //    string commandName = tokens[0];

        //    ICommand command = null;

        //    if (commandName == "Hello")
        //    {
        //        command = new HelloCommand();
        //    }
        //    else if (commandName == "Exit")
        //    {
        //        command = new ExitCommand();
        //    }

        //    string[] clearData = tokens.Skip(1).ToArray();
        //    string result = command.Execute(clearData);

        //    return result;
        //}
    }
}
