using Bytes2you.Validation;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using ProjectManager.Contracts;
using ProjectManager.Data;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Commands
{
    public class CreateUserCommand : ICommand
    {
        public CreateUserCommand(IDatabase database, IModelFactory modelsFactory)
        {
            this.Database = database;
            this.ModelsFactory = modelsFactory;
        }

        public IModelFactory ModelsFactory { get; set; }

        public IDatabase Database { get; set; }

        public string Execute(IList<string> parameters)
        {
            if (parameters.Count != 3)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            if (this.Database.Projects[int.Parse(parameters[0])].Users.Any() && 
                this.Database.Projects[int.Parse(parameters[0])].Users.Any(x => x.UserName == parameters[1]))
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            var project = int.Parse(parameters[0]);
            var user = this.ModelsFactory.CreateUser(parameters[1], parameters[2]);
            this.Database.Projects[project].Users.Add(user);

            return "Successfully created a new user!";
        }
    }
}
