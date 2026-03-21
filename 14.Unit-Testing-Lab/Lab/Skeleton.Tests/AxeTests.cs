using NUnit.Framework;
using System;

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
            Assert.That(dummy.Health, Is.EqualTo(80));
        }

        [Test]
        public void AxeShouldNotAttackWithBrokenWeapon()
        {
            // Arrange
            var axe = new Axe(10, -17);
            var dummy = new Dummy(100, 200);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                // Act
                axe.Attack(dummy);
            }, "Axe is broken.");
        }
    }
}