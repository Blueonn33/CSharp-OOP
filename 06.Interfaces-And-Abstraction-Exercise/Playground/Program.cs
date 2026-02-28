using System.Net.Http.Headers;

namespace Playground
{
    public class Program
    {
        static void Main(string[] args)
        {
            Doctor doctor = new Doctor();
            IWorker teacher = new Teacher();

            List<IWorker> workers = new();
            workers.Add(doctor);
            workers.Add(teacher);

            foreach (var worker in workers)
            {
                worker.Work();
            }

            doctor.Diagnose();

            List<IEmployee> employees = new();
            employees.Add(doctor);
        }
    }

    public interface IWorker
    {
        void Work();
    }

    public interface IEmployee
    {
        void GetSalary();
        void PayTaxes();
    }

    public class Doctor : IWorker, IEmployee
    {
        public void Work()
        {
            Console.WriteLine("Cure people");
        }

        public void Diagnose()
        {
            Console.WriteLine("Diagnoses sickness");
        }

        public void GetSalary()
        {
            throw new NotImplementedException();
        }

        public void PayTaxes()
        {
            Console.WriteLine("Paying :(");
        }
    }

    public class Teacher : IWorker
    {
        public void Work()
        {
            Console.WriteLine("Teach people");
        }

        public void CreateTest()
        {
            Console.WriteLine("Creates a test");
        }
    }

    public class Manager : IEmployee
    {
        public void GetSalary()
        {
            Console.WriteLine(4323);
        }

        public void PayTaxes()
        {
            Console.WriteLine(54534);
        }
    }
}
