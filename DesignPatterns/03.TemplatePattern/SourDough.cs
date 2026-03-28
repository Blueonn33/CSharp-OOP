namespace _03.TemplatePattern
{
    public class SourDough : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine($"Gathering ingredients for Sour dough");
        }

        public override void Bake()
        {
            Console.WriteLine($"Baking for 12 minutes");
        }
    }
}
