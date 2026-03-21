namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(1)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(3)]
        [TestCase(6)]
        public void TestMethod(int input)
        {
            // Arrange
            int expected = 5;

            // Act
            int actual = input + expected;

            // Assert
            Assert.AreNotEqual(expected, actual);
        }
    }
}
