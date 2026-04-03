using WildFarm.Abstract;
using WildFarm.FoodModels;

namespace WildFarm.FelineModels
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string region, string breed)
            : base(name, weight, region, breed) { }

        public override string ProduceSound() => "Meow";

        public override void Eat(Food food)
        {
            if (food is not Vegetable && food is not Meat)
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");

            this.Weight += food.Quantity * 0.30;
            this.FoodEaten += food.Quantity;
        }
    }

}
