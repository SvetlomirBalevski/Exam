using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Common.Contracts
{
    public interface ICommandProcessor
    {
        string Process(string input);
    }
}
