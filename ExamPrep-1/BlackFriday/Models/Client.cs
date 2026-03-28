namespace BlackFriday.Models
{
    public class Client : User
    {
        public Client(string userName, string email, bool hasDataAccess) : base(userName, email, hasDataAccess)
        {
        }


    }
}
