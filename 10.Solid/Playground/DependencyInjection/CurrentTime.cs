namespace Playground.DependencyInjection
{
    public class CurrentTime : ICurrentTime
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
