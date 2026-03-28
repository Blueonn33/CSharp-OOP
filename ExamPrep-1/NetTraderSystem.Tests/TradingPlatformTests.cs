using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

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
        public void Remove_ShouldReturnFalse_IfProductDoesNotExist()
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

        [Test]
        public void Remove_ShouldReturnTrue_IfProductExists()
        {
            TradingPlatform tradingPlatform = new TradingPlatform(10);

            var product = new Product("p1", "test", 389);
            tradingPlatform.AddProduct(product);


            bool result = tradingPlatform.RemoveProduct(product);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(tradingPlatform.Products, Is.Empty);
            });
        }

        [Test]
        public void Sell_ShouldReturnNull_IfProductDoesNotExist()
        {
            TradingPlatform tradingPlatform = new TradingPlatform(10);

            var product = new Product("p1", "test", 389);
            tradingPlatform.AddProduct(product);

            var otherProduct = new Product("other", "test", 343);

            Product result = tradingPlatform.SellProduct(otherProduct);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Null);
                Assert.That(tradingPlatform.Products, Is.EqualTo(new Product[] { product }));
            });
        }

        [Test]
        public void Sell_ShouldReturnTheProduct_IfItExists()
        {
            TradingPlatform tradingPlatform = new TradingPlatform(10);

            var product = new Product("p1", "test", 389);
            tradingPlatform.AddProduct(product);


            Product result = tradingPlatform.SellProduct(product);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.SameAs(product));
                Assert.That(tradingPlatform.Products, Is.Empty);
            });
        }

        [Test]
        public void InventoryReport_ShouldBeGeneratedSuccessfully_ForEmptyPlatform()
        {
            TradingPlatform tradingPlatform = new TradingPlatform(0);

            string result = tradingPlatform.InventoryReport();
            // Environment.NewLine
            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Inventory Report:");
            expectedOutput.Append("Available Products: 0");

            Assert.That(result, Is.EqualTo(expectedOutput.ToString()));
        }

        [Test]
        public void InventoryReport_ShouldBeGeneratedSuccessfully_ForFullPlatform()
        {
            TradingPlatform tradingPlatform = new TradingPlatform(10);

            var product = new Product("product_1", "test", 17.30);
            tradingPlatform.AddProduct(product);

            string result = tradingPlatform.InventoryReport();
            // Environment.NewLine
            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Inventory Report:");
            expectedOutput.AppendLine("Available Products: 1");
            expectedOutput.Append("Name: product_1, Category: test - $17,30");

            Assert.That(result, Is.EqualTo(expectedOutput.ToString()));
        }
    }
}