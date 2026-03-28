namespace _02.Composite.Models.Contracts
{
    public interface IGiftOperations
    {
        void AddGift(GiftBase gift);
        void RemoveGift(GiftBase gift);
    }
}
