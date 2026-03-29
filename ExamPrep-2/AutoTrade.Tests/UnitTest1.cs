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
    }
}
