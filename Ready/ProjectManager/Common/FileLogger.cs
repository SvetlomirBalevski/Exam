using log4net;

namespace ProjectManager.Common
{
    public class FileLogger : IFileLogger
    {
        private static ILog log;

        static FileLogger()
        {
            log = LogManager.GetLogger(typeof(FileLogger));
        }

        public void GetInfo(object message)
        {
            log.Info(message);
        }        

        public void Error(object message)
        {
            log.Error(message);
        }        

        public void FatalError(object message)
        {
            log.Fatal(message);
        }
    }
}
