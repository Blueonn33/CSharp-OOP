namespace _03.TemplatePattern
{
    public class WholeWheat : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine($"Gathering ingredients for Whole wheat");
        }

        public override void Bake()
        {
            Console.WriteLine($"Baking for 33 minutes");
        }
    }
}
