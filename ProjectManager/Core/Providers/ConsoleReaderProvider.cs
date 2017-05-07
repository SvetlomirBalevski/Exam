using ProjectManager.Core.Contracts;
using System;

namespace ProjectManager.Core.Providers
{
    public class ConsoleReaderProvider : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
