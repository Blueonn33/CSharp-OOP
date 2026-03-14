using _11.Solid.Interfaces;
using _11.Solid.Layouts;

public class Program
{
    static void Main()
    {
        ILayout simpleLayout = new SimpleLayout();
        IAppender consoleAppender = new ConsoleAppender(simpleLayout);
        ILogger logger = new Logger(consoleAppender);

        
    }
}