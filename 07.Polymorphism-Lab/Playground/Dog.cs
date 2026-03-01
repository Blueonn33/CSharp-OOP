namespace Playground
{
    public class Dog : Mammal
    {
        public void Bark()
        {
            Console.WriteLine("Bark");
        }
        public override void SayHello()
        {
            Console.WriteLine("I am a dog");
        }
    }
}
