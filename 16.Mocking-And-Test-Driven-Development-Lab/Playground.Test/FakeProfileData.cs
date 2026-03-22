namespace Playground.Test
{
    public class FakeProfileData : IProfileData
    {
        public List<Profile> All()
        {
            // Fake data for testing purposes

            return new List<Profile>
            {
                new Profile { Age = 20 },
                new Profile { Age = 22 },
                new Profile { Age = 10 },
            };
        }
    }
}
