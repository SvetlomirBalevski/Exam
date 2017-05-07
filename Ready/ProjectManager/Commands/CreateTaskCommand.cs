using ProjectManager.Common.Exceptions;
using ProjectManager.Contracts;
using ProjectManager.Data;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public class CreateTaskCommand : ICommand
    {
        public CreateTaskCommand(IDatabase database, IModelFactory modelsFactory)
        {
            this.Database = database;
            this.ModelsFactory = modelsFactory;
        }

        public IModelFactory ModelsFactory { get; set; }

        public IDatabase Database { get; set; }

        public string Execute(IList<string> parameters)
        {
            if (parameters.Count != 4)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            var projects = this.Database.Projects[int.Parse(parameters[0])];

            var owner = projects.Users[int.Parse(parameters[1])];

            var task = this.ModelsFactory.CreateTask(owner, parameters[2], parameters[3]);
            projects.Tasks.Add(task);

            return "Successfully created a new task!";
        }
    }
}
