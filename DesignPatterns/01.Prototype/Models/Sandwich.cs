namespace _01.Prototype.Models
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        public override SandwichPrototype Clone()
        {
            string ingredientList = GetIngredients();
            Console.WriteLine($"Cloning sandwich: {ingredientList}");

            return MemberwiseClone() as SandwichPrototype;
        }


        public string GetIngredients()
        {
            return $"{bread}, {meat}, {cheese}, {veggies}";
        }

    }
}
