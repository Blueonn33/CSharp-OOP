namespace WildFarm.Abstract
{
    public abstract class Animal
    {
        public string Name
        {
            get; protected set;
        }
        public double Weight
        {
            get; protected set;
        }
        public int FoodEaten
        {
            get; protected set;
        }

        public abstract string ProduceSound();
        public abstract void Eat(Food food);
    }
}
