using _11.Solid.Appenders;
using _11.Solid.Core;
using _11.Solid.Interfaces;
using _11.Solid.Layouts;
using _11.Solid.Services;

public class Program
{
    static void Main()
    {
        ILayout layout = new XmlLayout();
        IAppender appender = new FileAppender(layout, new LogFile());
        //consoleAppender.ReportLevel = ReportLevel.Error;

        ILogger logger = new Logger(appender);

        logger.Error("3/26/2015 2:09:11 PM", "Error parsing JSON.");
        logger.Info("3/26/2015 2:09:11 PM", "User Martin has successfully registered.");
    }
}