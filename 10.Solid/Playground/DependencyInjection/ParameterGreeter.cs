namespace Playground.DependencyInjection
{
    public class ParameterGreeter
    {
        public void Greet(ICurrentTime currentTime)
        {
            var timeNow = currentTime.Now;

            if (timeNow.Hour < 12)
            {
                Console.WriteLine("Good morning");
            }
            else if (timeNow.Hour >= 19)
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
