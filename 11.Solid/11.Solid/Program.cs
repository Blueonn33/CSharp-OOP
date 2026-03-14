using _11.Solid.Appenders;
using _11.Solid.Core;
using _11.Solid.Interfaces;
using _11.Solid.Layouts;

public class Program
{
    static void Main()
    {
        ILayout simpleLayout = new SimpleLayout();
        IAppender consoleAppender = new ConsoleAppender(simpleLayout);
        ILogger logger = new Logger(consoleAppender);

        logger.Error("3/26/2015 2:09:11 PM", "Error parsing JSON.");
        logger.Info("3/26/2015 2:09:11 PM", "User Martin has successfully registered.");
    }
}