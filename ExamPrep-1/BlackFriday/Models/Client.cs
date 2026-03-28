using System.Collections.ObjectModel;

namespace BlackFriday.Models
{
    public class Client : User
    {
        private readonly Dictionary<string, bool> purchases;
        public IReadOnlyDictionary<string, bool> Purchases
        {
            get;
        }

        public Client(string userName, string email) : base(userName, email, hasDataAccess: false)
        {
            purchases = new Dictionary<string, bool>();
            Purchases = new ReadOnlyDictionary<string, bool>(purchases);
        }

        public void PurchaseProduct(string productName, bool blackFridayFlag)
        {
            purchases[productName] = blackFridayFlag;
        }
    }
}
