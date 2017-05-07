using ProjectManager.Commands;
using ProjectManager.Commands.Contracts;
using ProjectManager.Common.Contracts;
using System;
using System.Linq;

namespace ProjectManager.Common
{
    public class CommandProcessor : ICommandProcessor
    {
        private ICommandsFactory factory;

        public CommandProcessor(ICommandsFactory factory)
        {
            this.factory = factory;
        }

        public string Process(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exceptions.UserValidationException("No command has been provided!");
            }

            if (input.Split(' ').Count() > 10)
            {
                throw new ArgumentException("Provided command is not adequate");
            }

            var command = this.factory.CreateCommandFromString(input.Split(' ')[0]);
            return command.Execute(input.Split(' ').Skip(1).ToList());
        }
    }
}
