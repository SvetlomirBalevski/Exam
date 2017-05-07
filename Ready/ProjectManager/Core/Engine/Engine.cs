using Bytes2you.Validation;
using ProjectManager.Common;
using ProjectManager.Common.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Providers;
using System;

namespace ProjectManager
{
    public class Engine : IEngine
    {
        private IFileLogger logger;
        private ICommandProcessor processor;
        private IReader reader;
        private IWriter writer;

        public Engine(IFileLogger logger, ICommandProcessor processor)
        {
            Guard.WhenArgument(logger, "Engine Logger provider").IsNull().Throw();

            Guard.WhenArgument(processor, "Engine Processor provider").IsNull().Throw();

            this.logger = logger;

            this.processor = processor;

            this.reader = new ConsoleReaderProvider();
            this.writer = new ConsoleWriterProvider();
        }

        public IReader Reader
        {
            get
            {
                return this.reader;
            }
        }

        public IWriter Writer
        {
            get
            {
                return this.writer;
            }
        }

        public void Start()
        {
            while (true)
            {
                var readed = this.reader.ReadLine();

                if (readed.ToLower() == "exit")
                {
                    this.writer.WriteLine("Program terminated.");
                    break;
                }

                try
                {
                    var executionResult = this.processor.Process(readed);
                    this.writer.WriteLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    this.writer.WriteLine(ex.Message);
                    this.logger.Error(ex.Message);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine($"Error was occures with message: {ex}");
                    this.logger.Error(ex.Message);
                }
            }
        }
    }
}
