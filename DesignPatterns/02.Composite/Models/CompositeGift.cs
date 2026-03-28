using _02.Composite.Models.Contracts;

namespace _02.Composite.Models
{
    public class CompositeGift : GiftBase, IGiftOperations
    {

        public override decimal CalculateTotalPrice()
        {
            throw new NotImplementedException();
        }

        public CompositeGift(string name, decimal price) : base(name, price)
        {
        }

        public void AddGift(GiftBase gift)
        {
            throw new NotImplementedException();
        }

        public void RemoveGift(GiftBase gift)
        {
            throw new NotImplementedException();
        }
    }
}
