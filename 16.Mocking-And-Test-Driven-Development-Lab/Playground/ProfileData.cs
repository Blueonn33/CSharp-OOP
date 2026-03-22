namespace Playground
{
    public class ProfileData
    {
        public List<Profile> All()
        {
            // Read database
            return new List<Profile>
            {
                new Profile { Username = "martin.marinov", FullName = "Martin Marinov", Age = 21 },
                new Profile { Username = "marin_martinov17", FullName = "Marin Martinov", Age = 23 },
                new Profile { Username = "raya.petkova", FullName = "Raya Petkova", Age = 18 },
            };
        }
    }
}
