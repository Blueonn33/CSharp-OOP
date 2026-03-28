using BlackFriday.Models.Contracts;

namespace BlackFriday.Models
{
    public abstract class User : IUser
    {
        public string UserName
        {
            get;
        }

        public abstract bool HasDataAccess
        {
            get;
        }

        public string Email
        {
            get;
        }
    }
}
