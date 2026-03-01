namespace Playground
{
    public abstract class Mammal : IAnimal
    {
        public string Name
        {
            get; set;
        }
        public abstract void SayHello();

        public virtual void BaseMethod()
        {
            Console.WriteLine("This is base!");
        }
    }
}
