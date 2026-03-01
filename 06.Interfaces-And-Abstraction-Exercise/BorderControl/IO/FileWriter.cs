using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorderControl.IO.Interfaces;

namespace BorderControl.IO
{
    public class FileWriter : IWriter
    {
        public void WriteLine(string line)
        {
            string filePath = "../../../test.txt";

            using StreamWriter streamWriter = new StreamWriter(filePath, true);

            streamWriter.WriteLine(line);
        }
    }
}
