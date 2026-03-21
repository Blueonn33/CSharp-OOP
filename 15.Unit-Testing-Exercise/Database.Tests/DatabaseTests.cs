using System;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database(1, 2);
        }

        [Test]
        public void CreatingDatabaseCountShouldBeCorrect()
        {
            // Arrange
            int expectedResult = 2;

            // Assert
            Assert.AreEqual(expectedResult, database.Count);
        }

        [TestCase(new int[] { 1, 2 })]
        public void CreatingDatabaseShouldAddElementsCorrectly(int[] expectedData)
        {
            Database database = new Database(expectedData);

            Assert.AreEqual(expectedData, database.Fetch());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        public void CreatingDatabaseShouldThrowExceptionWhenCountIsMoreThan16(int[] data)
        {
            Assert.Throws<InvalidOperationException>(() => new Database(data));
        }

        [Test]
        public void DatabaseCountShouldWorkCorrectly()
        {
            int expectedResult = 2;

            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]
        public void DatabaseAddMethodShouldAddElementsCorrectly()
        {
            int[] expectedResult = new int[] { 1, 2, 17 };

            database.Add(17);

            Assert.AreEqual(expectedResult, database.Fetch());
        }
    }
}
