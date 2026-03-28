using _02.Composite.Models;

namespace _02.Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SingleGift phone = new SingleGift("Phone", 257);
            phone.CalculateTotalPrice();

            Console.WriteLine();

            CompositeGift rootBox = new CompositeGift("Root box", 0);

            SingleGift truck = new SingleGift("Truck", 50);
            SingleGift plane = new SingleGift("Plane", 100);

            rootBox.AddGift(truck);
            rootBox.AddGift(plane);

            CompositeGift smallerRootBox = new CompositeGift("Smaller Root box", 0);
            smallerRootBox.AddGift(new SingleGift("Doll", 23));
            smallerRootBox.AddGift(new SingleGift("Car", 45));

            rootBox.AddGift(smallerRootBox);

            Console.WriteLine(rootBox.CalculateTotalPrice());
        }
    }
}
