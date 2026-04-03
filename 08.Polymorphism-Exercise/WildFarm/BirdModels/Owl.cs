using WildFarm.Abstract;
using WildFarm.FoodModels;

namespace WildFarm.BirdModels
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize) { }

        public override string ProduceSound() => "Hoot Hoot";

        public override void Eat(Food food)
        {
            if (food is not Meat)
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");

            this.Weight += food.Quantity * 0.25;
            this.FoodEaten += food.Quantity;
        }
    }
}
