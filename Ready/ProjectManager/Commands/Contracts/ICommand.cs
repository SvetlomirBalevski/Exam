using ProjectManager.Data;
using ProjectManager.Models;
using System.Collections.Generic;

namespace ProjectManager.Commands
{
    public interface ICommand
    {
         IDatabase Database { get; set; }

        string Execute(IList<string> parameters);
    }
}
