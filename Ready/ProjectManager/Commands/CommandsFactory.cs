using ProjectManager.Commands.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager.Commands
{
    public class CommandsFactory : ICommandsFactory
    {
        public CommandsFactory(Database database, ModelsFactory modelFactory)
        {
            this.Database = database;
            this.ModelsFactory = modelFactory;
        }

        public ModelsFactory ModelsFactory { get; set; }

        public Database Database { get; set; }

        public ICommand CreateCommandFromString(string commandName)
        {
            var name = this.BuildCommand(commandName);

            switch (name)
            {
                case "createproject": return new CreateProjectCommand(Database, ModelsFactory);
                case "createtask": return new CreateTaskCommand(Database, ModelsFactory);
                case "listprojects": return new ListProjectsCommand(Database);
                case "createuser": return new CreateUserCommand(Database, ModelsFactory);
                default: throw new UserValidationException("The passed command is not valid!");
            }
        }

        private string BuildCommand(string parameters)
        {
            var command = string.Empty;

            for (int i = 0; i < parameters.Length; i++)
            {
                command += parameters[i].ToString().ToLower();
            }

            return command;
        }
    }
}