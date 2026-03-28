using BlackFriday.Core.Contracts;

namespace BlackFriday.Core
{
    public class Controller : IController
    {
        public string RegisterUser(string userName, string email, bool hasDataAccess)
        {
            throw new NotImplementedException();
        }

        public string AddProduct(string productType, string productName, string userName, double basePrice)
        {
            throw new NotImplementedException();
        }

        public string UpdateProductPrice(string productName, string userName, double newPriceValue)
        {
            throw new NotImplementedException();
        }

        public string RefreshSalesList(string userName)
        {
            throw new NotImplementedException();
        }

        public string PurchaseProduct(string userName, string productName, bool blackFridayFlag)
        {
            throw new NotImplementedException();
        }

        public string ApplicationReport()
        {
            throw new NotImplementedException();
        }
    }
}
