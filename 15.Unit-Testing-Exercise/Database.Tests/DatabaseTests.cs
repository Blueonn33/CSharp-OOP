using System;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void CreatingDatabaseCountShouldBeCorrect()
        {
            // Arrange
            int expectedResult = 2;

            // Act
            Database database = new Database(1, 2);

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
        public void CreatingDatabaseShouldThrowExceptionWhenCountIsMoreThan16(int[] expectedData)
        {
            Database database = new Database(expectedData);

            Assert.Throws<InvalidOperationException>(() => database.Add(21));
        }

        //[Test]
        //public void CreatingDatabaseShouldSetInnerArrayWith16Elements()
        //{
        //    // Arrange
        //    int expectedResult = 16;

        //    // Act
        //    Database database = new Database(1, 2);
        //    int actual = database.Fetch().Length;

        //    // Assert
        //    Assert.AreEqual(expectedResult, actual);
        //}
    }
}
