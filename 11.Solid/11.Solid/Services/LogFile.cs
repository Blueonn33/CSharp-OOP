using _11.Solid.Interfaces;
using System.Text;

namespace _11.Solid.Services
{
    public class LogFile : ILogFile
    {
        private const string FilePath = "../../../log.txt";

        public int Size
        {
            get
            {
                if (!File.Exists(FilePath))
                {
                    return 0;
                }

                FileInfo fileInfo = new FileInfo(FilePath);
                return (int)fileInfo.Length;
            }
        }

        public void Write(string message)
        {
            File.AppendAllText(FilePath, message + Environment.NewLine, Encoding.UTF8);
        }
    }
}
