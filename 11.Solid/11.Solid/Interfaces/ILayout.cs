using _11.Solid.Enums;

namespace _11.Solid.Interfaces
{
    public interface ILayout
    {
        string Format(string date, ReportLevel reportLevel, string message);
    }
}
