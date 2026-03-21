namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void TestMethod()
        {
            // Arrange
            int expected = 5;

            // Act
            int actual = 1 + expected;

            // Assert
            Assert.AreNotEqual(expected, actual);
        }
    }
}
