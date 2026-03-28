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

            rootBox.CalculateTotalPrice();
        }
    }
}
