using WildFarm.Abstract;

namespace WildFarm.BirdModels
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize) { }

        public override string ProduceSound() => "Cluck";

        public override void Eat(Food food)
        {
            this.Weight += food.Quantity * 0.35;
            this.FoodEaten += food.Quantity;
        }
    }

}
