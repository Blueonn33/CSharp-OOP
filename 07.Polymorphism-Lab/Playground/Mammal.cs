namespace Playground
{
    public abstract class Mammal : IAnimal
    {
        public string Name { get; set; }
        public abstract void SayHello();
    }
}
