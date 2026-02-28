using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Telephony.Core.Interfaces;
using Telephony.IO.Interfaces;
using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] urls = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            ICallable collable;
            IBrowsable browsable;

            foreach (string phoneNumber in phoneNumbers)
            {
                try
                {
                    if (phoneNumber.Length == 7)
                    {
                        collable = new StationaryPhone();
                    }
                    else
                    {
                        collable = new Smartphone();
                    }

                    writer.WriteLine(collable.Call(phoneNumber));
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            foreach (string url in urls)
            {
                try
                {
                    browsable = new Smartphone();
                    writer.WriteLine(browsable.Browse(url));
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
