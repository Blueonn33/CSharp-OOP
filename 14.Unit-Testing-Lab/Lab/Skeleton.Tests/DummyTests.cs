using NUnit.Framework;
using System;

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
            // Arrange
            var axe = new Axe(10, 100);
            var dummy = new Dummy(0, 200);

            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                // Act
                axe.Attack(dummy);
            }, "Dummy is dead.");
        }
    }
}