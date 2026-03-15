using _11.Solid.Enums;
using _11.Solid.Interfaces;

namespace _11.Solid.Appenders
{
    public class FileAppender : IAppender
    {
        private readonly ILayout _layout;
        private readonly ILogFile _logFile;

        public ILogFile File
        {
            get;
        }

        public FileAppender(ILayout layout, ILogFile logFile)
        {
            _layout = layout;
            _logFile = logFile;
        }

        public ReportLevel ReportLevel
        {
            get;
            set;
        }

        public int MessagesAppended
        {
            get;
            private set;
        }

        public void Append(string date, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= ReportLevel)
            {
                string formattedMessage = _layout.Format(date, reportLevel, message);

                _logFile.Write(formattedMessage);

                MessagesAppended++;
            }
        }
    }
}
