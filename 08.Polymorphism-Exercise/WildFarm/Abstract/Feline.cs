using WildFarm.Abstract;

namespace WildFarm
{
    public abstract class Feline : Mammal
    {
        public string Breed
        {
            get; set;
        }

        public override string ToString()
        {
            return $"Felines = {GetType().Name}[{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
