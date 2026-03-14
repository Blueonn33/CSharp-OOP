using _11.Solid.Enums;
using _11.Solid.Interfaces;
using System.Text;

namespace _11.Solid.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format(string date, ReportLevel reportLevel, string message)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<log>");
            sb.AppendLine($"\t<date>{date}</date>");
            sb.AppendLine($"\t<level>{reportLevel}</level>");
            sb.AppendLine($"\t<message>{message}</message>");
            sb.Append("</log>");

            return sb.ToString();
        }
    }
}
