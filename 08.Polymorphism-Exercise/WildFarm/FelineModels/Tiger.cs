using WildFarm.Abstract;
using WildFarm.FoodModels;

namespace WildFarm.FelineModels
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string region, string breed)
            : base(name, weight, region, breed) { }

        public override string ProduceSound() => "ROAR!!!";

        public override void Eat(Food food)
        {
            if (food is not Meat)
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");

            this.Weight += food.Quantity * 1.00;
            this.FoodEaten += food.Quantity;
        }
    }

}
