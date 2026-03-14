using _11.Solid.Appenders;
using _11.Solid.Enums;
using _11.Solid.Interfaces;
using _11.Solid.Layouts;

namespace _11.Solid.Core
{
    public class Logger : ILogger
    {
        public Logger(IAppender appender)
        {

        }

        public void Info(string date, string message) => Log(date, ReportLevel.Info, message);

        public void Warning(string date, string message) => Log(date, ReportLevel.Warning, message);

        public void Error(string date, string message) => Log(date, ReportLevel.Error, message);

        public void Critical(string date, string message) => Log(date, ReportLevel.Critical, message);

        public void Fatal(string date, string message) => Log(date, ReportLevel.Fatal, message);

        private void Log(string date, ReportLevel reportLevel, string message)
        {
            ConsoleAppender consoleAppender = new(new SimpleLayout());

            consoleAppender.Append(date, reportLevel, message);
        }
    }
}
