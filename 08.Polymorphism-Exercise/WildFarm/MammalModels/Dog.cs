using WildFarm.Abstract;
using WildFarm.FoodModels;

namespace WildFarm.MammalModels
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string region)
            : base(name, weight, region) { }

        public override string ProduceSound() => "Woof!";

        public override void Eat(Food food)
        {
            if (food is not Meat)
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");

            this.Weight += food.Quantity * 0.40;
            this.FoodEaten += food.Quantity;
        }
    }
}
