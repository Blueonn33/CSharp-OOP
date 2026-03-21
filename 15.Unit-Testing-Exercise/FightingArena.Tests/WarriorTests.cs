using NUnit.Framework;
using System;

namespace FightingArena.Tests
{
    public class WarriorTests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            Warrior w = new Warrior("Gosho", 50, 100);

            Assert.AreEqual("Gosho", w.Name);
            Assert.AreEqual(50, w.Damage);
            Assert.AreEqual(100, w.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Name_ShouldThrow_WhenInvalid(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 10, 50));
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void Damage_ShouldThrow_WhenZeroOrNegative(int dmg)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Test", dmg, 50));
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void HP_ShouldThrow_WhenNegative(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Test", 10, hp));
        }

        [TestCase(29)]
        [TestCase(0)]
        public void Attack_ShouldThrow_WhenAttackerHPTooLow(int hp)
        {
            Warrior attacker = new Warrior("A", 50, hp);
            Warrior defender = new Warrior("B", 40, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [TestCase(29)]
        [TestCase(10)]
        public void Attack_ShouldThrow_WhenDefenderHPTooLow(int hp)
        {
            Warrior attacker = new Warrior("A", 50, 100);
            Warrior defender = new Warrior("B", 40, hp);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Attack_ShouldThrow_WhenAttackingStrongerEnemy()
        {
            Warrior attacker = new Warrior("A", 50, 50);
            Warrior defender = new Warrior("B", 60, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void Attack_ShouldReduceHP_Correctly()
        {
            Warrior attacker = new Warrior("A", 50, 100);
            Warrior defender = new Warrior("B", 40, 100);

            attacker.Attack(defender);

            Assert.AreEqual(60, attacker.HP);
            Assert.AreEqual(50, defender.HP);
        }

        [Test]
        public void Attack_ShouldSetDefenderHPToZero_WhenDamageIsGreater()
        {
            Warrior attacker = new Warrior("A", 200, 100);
            Warrior defender = new Warrior("B", 40, 150);

            attacker.Attack(defender);

            Assert.AreEqual(0, defender.HP);
        }
    }
}