using System.Numerics;
using System.Threading.Channels;
using BorderControl.Core;
using BorderControl.Core.Interfaces;
using BorderControl.IO;
using BorderControl.IO.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new FileWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}