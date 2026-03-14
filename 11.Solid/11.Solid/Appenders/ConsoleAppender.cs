using _11.Solid.Enums;
using _11.Solid.Interfaces;

namespace _11.Solid.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private readonly ILayout _layout;

        public ConsoleAppender(ILayout layout)
        {
            _layout = layout;
        }

        public ReportLevel ReportLevel
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int MessagesAppended
        {
            get;
            private set;
        }

        public void Append(string date, ReportLevel reportLevel, string message)
        {
            Console.WriteLine(_layout.Format(date, reportLevel, message));

            MessagesAppended++;
        }
    }
}
