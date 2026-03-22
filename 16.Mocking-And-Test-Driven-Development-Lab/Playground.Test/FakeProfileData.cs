namespace Playground.Test
{
    public class FakeProfileData : IProfileData
    {
        public List<Profile> All()
        {
            // Fake data for testing purposes

            return new List<Profile>
            {
                new Profile { Username = "testprofile22", Age = 20 },
                new Profile { Username = "testprofile34", Age = 22 },
                new Profile { Username = "testprofile44", Age = 10 },
            };
        }
    }
}
