namespace WildFarm.Abstract
{
    public abstract class Mammal : Animal
    {
        public string LivingRegion
        {
            get; set;
        }

        public override string ToString()
        {
            return $"Mice and Dogs = {GetType().Name}[{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
