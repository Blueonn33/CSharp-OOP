namespace Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var profileRepository = new ProfileRepository(new RealProfileData());
        }
    }
}
