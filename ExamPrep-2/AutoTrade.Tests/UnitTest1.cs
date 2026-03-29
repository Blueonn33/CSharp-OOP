namespace AutoTrade.Tests
{
    [TestFixture]
    public class DealerShopTests
    {
        [Test]
        public void Constructor_ShouldInitialize_WithValidCapacity()
        {
            int expectedCapacity = 10;

            DealerShop shop = new DealerShop(10);

            Assert.AreEqual(expectedCapacity, shop.Capacity);
            Assert.IsNotNull(shop.Vehicles);
            Assert.IsEmpty(shop.Vehicles);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Constructor_ShouldThrowException_WhenCapacityIsZeroOrNegative(int capacity)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new DealerShop(capacity));

            Assert.AreEqual("Capacity must be a positive value.", ex.Message);
        }

        [Test]
        public void AddVehicle_ShouldAddVehicle_WhenInventoryIsNotFull()
        {
            DealerShop dealerShop = new DealerShop(3);

            Vehicle vehicle = new Vehicle("Toyota", "Camry", 2024);

            string result = dealerShop.AddVehicle(vehicle);

            Assert.AreEqual(1, dealerShop.Vehicles.Count);

            Assert.AreEqual($"Added {vehicle}", result);
            Assert.Contains(vehicle, dealerShop.Vehicles.ToList());
        }

        [Test]
        public void AddVehicle_ShouldThrowException_WhenInventoryIsFull()
        {
            DealerShop dealerShop = new DealerShop(2);

            dealerShop.AddVehicle(new Vehicle("Toyota", "Camry", 2024));
            dealerShop.AddVehicle(new Vehicle("Toyota", "Tundra", 2026));

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => dealerShop.AddVehicle(new Vehicle("Aston Martin", "Vulcan", 2026)));

            Assert.AreEqual("Inventory is full", ex.Message);
        }

        [Test]
        public void SellVehicle_ShouldRemoveVehicle_WhenItExists()
        {
            DealerShop dealerShop = new DealerShop(1);

            Vehicle vehicle = new Vehicle("Toyota", "Camry", 2024);
            dealerShop.AddVehicle(vehicle);

            bool result = dealerShop.SellVehicle(vehicle);
            Assert.IsTrue(result);
            Assert.IsEmpty(dealerShop.Vehicles);
        }
    }
}
