using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Common
{
    public interface IFileLogger
    {
        void GetInfo(object message);

        void Error(object message);

        void FatalError(object message);
    }
}
