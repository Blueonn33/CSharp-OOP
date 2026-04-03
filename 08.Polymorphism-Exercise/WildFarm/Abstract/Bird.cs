namespace WildFarm.Abstract
{
    public abstract class Bird : Animal
    {
        public double WingSize
        {
            get; set;
        }

        public override string ToString()
        {
            return $"Birds = {GetType().Name}[{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
