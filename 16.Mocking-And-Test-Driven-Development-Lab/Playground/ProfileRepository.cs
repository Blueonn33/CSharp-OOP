namespace Playground
{
    public class ProfileRepository
    {
        private ProfileData data;

        public ProfileRepository()
        {
            this.data = new ProfileData();
        }

        public Profile GetByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            return this.data.All()
                .FirstOrDefault(u => u.Username == username) ?? throw new InvalidOperationException();
        }

        public List<Profile> GetAllAdults()
        {
            return this.data.All().Where(u => u.Age >= 18).ToList();
        }

        // mar -> Martin, Marin, Marmaduk
        public List<Profile> GetByFullName(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return new List<Profile>();
            }

            return this.data
                .All()
                .Where(u => u.FullName.ToLower().Contains(searchTerm.ToLower()))
                .ToList();
        }
    }
}
