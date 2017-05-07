using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Contracts
{
    public interface ITask
    {
        string State { get; set; }

        string Name { get; set; }

        IUser Owner { get; set; }
    }
}
