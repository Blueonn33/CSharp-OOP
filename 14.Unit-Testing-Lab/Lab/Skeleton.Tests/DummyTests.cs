using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyShouldLoseHealthIfAttacked()
        {
            // Arrange
            var axe = new Axe(10, 100);
            var dummy = new Dummy(100, 200);

            // Act
            axe.Attack(dummy);

            // Assert
            Assert.That(dummy.Health, Is.EqualTo(90));
        }

        [Test]
        public void DeadDummyShouldThrowExceptionIfAttacked()
        {
            // Assert
            var axe = new Axe(10, 100);
            var dummy = new Dummy(0, 200);

            // 
        }
    }
}