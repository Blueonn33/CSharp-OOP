namespace Playground.DependencyInjection
{
    public class Greeter
    {
        private ICurrentTime currentTime;

        public Greeter(ICurrentTime currentTime)
        {
            this.currentTime = currentTime;
        }

        public void Greet()
        {
            var timeNow = this.currentTime.Now;

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
