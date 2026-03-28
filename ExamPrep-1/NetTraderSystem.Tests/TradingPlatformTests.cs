namespace NetTraderSystem.Tests
{
    public class TradingPlatformTests
    {
        [Test]
        // TradingPlatformShouldBeInitializedSuccessfully
        public void TradingPlatform_ShouldBeInitialized_Successfully()
        {
            TradingPlatform tradingPlatform = new TradingPlatform(10);
            Assert.That(tradingPlatform.Products, Is.Empty);
        }

        [Test]
        public void Products_ShoudBeAdded_Successfully()
        {
            TradingPlatform tradingPlatform = new TradingPlatform(10);
            //Product[] addedProducts = new Product[10];
            List<Product> addedProducts = new List<Product>(capacity: 10);

            for (int i = 0; i < 10; i++)
            {
                var product = new Product($"product_{i + 1}", "test", 17.3);

                addedProducts.Add(product);
                var result = tradingPlatform.AddProduct(addedProducts[i]);

                Assert.Multiple(() =>
                {
                    Assert.That(result, Is.EqualTo($"Product product_{i + 1} added successfully"));
                    Assert.That(tradingPlatform.Products, Is.EqualTo(addedProducts));
                });
            }
        }

        [Test]
        public void Products_ShoudNotBeAdded_IfLimitIsReached()
        {
            TradingPlatform tradingPlatform = new TradingPlatform(0);

            string result = tradingPlatform.AddProduct(new Product("impossible", "kniga", 10.2));

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo("Inventory is full"));
                Assert.That(tradingPlatform.Products, Is.Empty);
            });
        }

        [Test]
        public void Remove_ShouldReturnFalse_IfProductsDoesNotExist()
        {
            TradingPlatform tradingPlatform = new TradingPlatform(10);

            var product = new Product("p1", "test", 389);
            tradingPlatform.AddProduct(product);

            var otherProduct = new Product("other", "test", 343);

            bool result = tradingPlatform.RemoveProduct(otherProduct);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.False);
                Assert.That(tradingPlatform.Products, Is.EqualTo(new Product[] { product }));
            });
        }
    }
}