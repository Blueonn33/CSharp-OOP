namespace WildFarm.Abstract
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity
        {
            get; protected set;
        }
    }
}