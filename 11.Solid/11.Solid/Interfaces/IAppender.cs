using _11.Solid.Enums;

namespace _11.Solid.Interfaces
{
    public interface IAppender
    {
        ReportLevel ReportLevel
        {
            get; set;
        }

        int MessagesAppended
        {
            get;
        }

        void Append(string date, ReportLevel reportLevel, string message);
    }
}
