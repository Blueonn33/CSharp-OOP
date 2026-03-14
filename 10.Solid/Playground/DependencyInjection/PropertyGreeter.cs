namespace Playground.DependencyInjection
{
    public class PropertyGreeter
    {
        private ICurrentTime currentTime;

        public ICurrentTime CurrentTime
        {
            set
            {
                this.currentTime = value;
            }
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
