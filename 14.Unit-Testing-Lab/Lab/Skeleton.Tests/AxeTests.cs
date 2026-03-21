using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeShouldLoseDurabilityAfterEachAttack()
        {
            // Arrange
            var axe = new Axe(10, 20);
            var dummy = new Dummy(100, 200);

            // Act
            axe.Attack(dummy);
            axe.Attack(dummy);

            // Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(18));
        }
    }
}