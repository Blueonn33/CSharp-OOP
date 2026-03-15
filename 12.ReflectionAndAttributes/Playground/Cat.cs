namespace Playground
{
    internal class Cat : Animal, IAnimal
    {
        private string color;

        public Cat(string name, string color)
        {
            this.Name = name;
            this.color = color;
        }

        public string Mew()
        {
            return $"I am {this.Name} - {this.color}. Mew!";
        }
    }
}
