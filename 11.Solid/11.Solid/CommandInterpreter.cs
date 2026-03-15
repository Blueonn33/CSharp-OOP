using _11.Solid.Enums;
using _11.Solid.Interfaces;

namespace _11.Solid
{
    public class CommandInterpreter
    {
        public void Run()
        {
            int appenderCount = int.Parse(Console.ReadLine());

            List<IAppender> appenders = new List<IAppender>();

            for (int i = 0; i < appenderCount; i++)
            {
                string[] parts = Console.ReadLine().Split();

                string appenderType = parts[0];
                string layoutType = parts[1];

                ReportLevel reportLevel = ReportLevel.Info;

                if (parts.Length == 3)
                {
                    reportLevel = Enum.Parse<ReportLevel>(parts[2], true);
                }

                ILayout layout = CreateLayout(layoutType);
                IAppender appender = CreateAppender(appenderType, layout);
            }
        }

        private IAppender CreateAppender(string appenderType, ILayout layout)
        {
            throw new NotImplementedException();
        }

        private ILayout CreateLayout(string layoutType)
        {
            throw new NotImplementedException();
        }
    }
}
