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
        }
    }
}
