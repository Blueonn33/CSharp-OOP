namespace Playground.DependencyInjection
{
    public class Greeter
    {
        public void Greet()
        {
            var timeNow = DateTime.Now;

            if (timeNow.Hour < 12)
            {
                Console.WriteLine("Good morning");
            }
            else if (timeNow.Hour > 19)
            {
                Console.WriteLine("Good evening");
            }
            else
            {
                Console.WriteLine("Good afternoon");
            }
        }
    }
}
