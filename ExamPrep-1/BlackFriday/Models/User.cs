using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;

namespace BlackFriday.Models
{
    public abstract class User : IUser
    {
        public string UserName
        {
            get;
        }

        public bool HasDataAccess
        {
            get;
        }

        public string Email
        {
            get;
        }

        protected User(string userName, string email, bool hasDataAccess)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException(ExceptionMessages.UserNameRequired);
            }

            if (string.IsNullOrEmpty(email))
            {
                if (hasDataAccess)
                {
                    email = "hidden";
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.EmailRequired);
                }
            }

            UserName = userName;
            Email = email;
            HasDataAccess = hasDataAccess;
        }

        public override string ToString()
        {
            return $"{UserName} - Status: {GetType().Name}, Contact Info: {Email}";
        }
    }
}
