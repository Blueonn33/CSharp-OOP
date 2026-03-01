using BorderControl.Core.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            List<IBirthable> society = new();

            while (true)
            {
                string input = reader.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                IBirthable birthable;

                string type = tokens[0];

                switch (type)
                {
                    case "Citizen":
                        birthable = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                        break;
                    case "Pet":
                        birthable = new Pet(tokens[1], tokens[2]);
                        break;
                    default:
                        continue;
                }

                society.Add(birthable);
            }

            string year = reader.ReadLine();

            foreach (IBirthable entity in society)
            {
                if (entity.Birthdate.EndsWith(year))
                {
                    writer.WriteLine(entity.Birthdate);
                }
            }
        }
    }
}
