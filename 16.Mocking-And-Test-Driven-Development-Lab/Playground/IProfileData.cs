namespace Playground
{
    public interface IProfileData
    {
        List<Profile> All();

        Profile Get(int id);

        void Delete(string username);
    }
}
