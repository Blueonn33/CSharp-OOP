using Moq;

namespace FakeAxeAndDummy.Tests
{
    public class HeroTests
    {
        [Test]
        public void HeroGainsExperienceWhenTargetIsDead()
        {
            // Arrange
            const int experience = 250;
            var targetMock = new Mock<ITarget>();

            targetMock
                .Setup(t => t.IsDead())
                .Returns(true);

            targetMock
                .Setup(t => t.GiveExperience())
                .Returns(experience);

            var weaponMock = new Mock<IWeapon>();

            var hero = new Hero("TestHero", weaponMock.Object);

            // Act
            hero.Attack(targetMock.Object);

            // Assert
            Assert.That(hero.Experience == experience);
        }
    }
}
