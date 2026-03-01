namespace Playground
{
    public class Cat : Mammal
    {
        public void Mew()
        {
            Console.WriteLine("Mew");
        }
        public override void SayHello()
        {
            Console.WriteLine("I am a cat!");
        }
        public override void BaseMethod()
        {
            Console.WriteLine("This is a cat");
        }
    }
}
