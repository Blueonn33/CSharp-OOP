using WildFarm.Abstract;

namespace WildFarm.MammalModels
{
    public class Dog : Mammal
    {
        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
