using ProjectManager.Data;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Commands.Contracts
{
    /// <summary>
    /// Create Commands from string
    /// </summary>
   public interface ICommandsFactory
    {
        ModelsFactory ModelsFactory { get; set; }

        Database Database { get; set; }

        ICommand CreateCommandFromString(string commandName);
    }
}
