namespace _03.TemplatePattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            SourDough sourDough = new SourDough();
            sourDough.MakeBread();

            TwelveGrain grain = new TwelveGrain();
            grain.MakeBread();

            WholeWheat wheat = new WholeWheat();
            wheat.MakeBread();
        }
    }
}

