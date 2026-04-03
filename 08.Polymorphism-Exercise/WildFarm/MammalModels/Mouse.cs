using WildFarm.Abstract;
using WildFarm.FoodModels;

namespace WildFarm.MammalModels
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string region)
            : base(name, weight, region) { }

        public override string ProduceSound() => "Squeak";

        public override void Eat(Food food)
        {
            if (food is not Vegetable && food is not Fruit)
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");

            this.Weight += food.Quantity * 0.10;
            this.FoodEaten += food.Quantity;
        }
    }
}
