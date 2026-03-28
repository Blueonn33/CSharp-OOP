using _02.Composite.Models.Contracts;

namespace _02.Composite.Models
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private readonly List<GiftBase> gifts;

        public CompositeGift(string name, decimal price) : base(name, price)
        {
            gifts = new();
        }

        public override decimal CalculateTotalPrice()
        {
            decimal total = 0;

            foreach (var gift in gifts)
            {
                total += gift.CalculateTotalPrice();
            }

            return total;
        }

        public void AddGift(GiftBase gift)
        {
            gifts.Add(gift);
        }

        public void RemoveGift(GiftBase gift)
        {
            gifts.Remove(gift);
        }
    }
}
