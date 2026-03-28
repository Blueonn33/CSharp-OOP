namespace _03.TemplatePattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            SourDough sourDough = new SourDough();
            sourDough.MakeBread();
            Console.WriteLine();

            TwelveGrain grain = new TwelveGrain();
            grain.MakeBread();
            Console.WriteLine();

            WholeWheat wheat = new WholeWheat();
            wheat.MakeBread();
            Console.WriteLine();
        }
    }
}

