using ProjectManager.Commands;
using ProjectManager.Commands.Contracts;
using ProjectManager.Common;
using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager
{
    public class Startup
    {
        public static void Main()
        {
            var fileLogger = new FileLogger();
            var database = new Database();
            var modelsFactory = new ModelsFactory();
            var commandsFactory = new CommandsFactory(database, modelsFactory);
            var commandCPU = new CommandProcessor(commandsFactory);

            var engine = new Engine(fileLogger, commandCPU);

            var provider = new EngineProvider(engine);
            provider.Start();
        }
    }
}
