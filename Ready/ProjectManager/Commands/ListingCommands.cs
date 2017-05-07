using Bytes2you.Validation;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public class ListProjectsCommand : ICommand
    {
        public ListProjectsCommand(IDatabase database)
        {
            Guard.WhenArgument(database, "ListProjectsCommand Database").IsNull().Throw();
            this.Database = database;
        }

        public IDatabase Database { get; set; }

        public string Execute(IList<string> parameters)
        {
            if (parameters.Count != 0)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            return string.Join(Environment.NewLine, this.Database.Projects);
        }
    }
}
