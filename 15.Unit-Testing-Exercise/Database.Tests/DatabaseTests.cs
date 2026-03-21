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
            Database database = new Database(1, 2);

            Assert.AreEqual(expectedData, database.Fetch());
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
