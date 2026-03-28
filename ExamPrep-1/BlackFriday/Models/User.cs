using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;

namespace BlackFriday.Models
{
    public abstract class User : IUser
    {
        private string userName;
        private string email;

        public string UserName
        {
            get => userName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UserNameRequired);
                }

                userName = value;
            }
        }

        public bool HasDataAccess
        {
            get;
        }

        public string Email
        {
            get => email;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmailRequired);
                }

                email = value;
            }
        }

        protected User(string userName, string email, bool hasDataAccess)
        {
            if (hasDataAccess)
            {
                email = "hidden";
            }

            UserName = userName;
            Email = hasDataAccess ? "hidden" : email;
            HasDataAccess = hasDataAccess;
        }

        public override string ToString()
        {
            return $"{UserName} - Status: {GetType().Name}, Contact Info: {Email}";
        }
    }
}
