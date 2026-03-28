namespace BlackFriday.Models
{
    public class Admin : User
    {
        public Admin(string userName, string email, bool hasDataAccess) : base(userName, email, hasDataAccess: true)
        {
        }
    }
}
