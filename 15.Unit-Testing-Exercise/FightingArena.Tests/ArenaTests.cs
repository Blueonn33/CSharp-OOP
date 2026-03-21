using NUnit.Framework;
using System;
using System.Linq;

namespace FightingArena.Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Constructor_ShouldInitializeCollection()
        {
            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void Enroll_ShouldAddWarrior()
        {
            Warrior w = new Warrior("A", 10, 100);

            arena.Enroll(w);

            Assert.AreEqual(1, arena.Count);
            Assert.IsTrue(arena.Warriors.Any(x => x.Name == "A"));
        }

        [Test]
        public void Enroll_ShouldThrow_WhenWarriorAlreadyExists()
        {
            Warrior w = new Warrior("A", 10, 100);

            arena.Enroll(w);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("A", 20, 200)));
        }

        [Test]
        public void Fight_ShouldThrow_WhenAttackerMissing()
        {
            arena.Enroll(new Warrior("B", 20, 100));

            Assert.Throws<InvalidOperationException>(() => arena.Fight("A", "B"));
        }

        [Test]
        public void Fight_ShouldThrow_WhenDefenderMissing()
        {
            arena.Enroll(new Warrior("A", 20, 100));

            Assert.Throws<InvalidOperationException>(() => arena.Fight("A", "B"));
        }

        [Test]
        public void Fight_ShouldReduceHP_OfBothWarriors()
        {
            Warrior attacker = new Warrior("A", 30, 100);
            Warrior defender = new Warrior("B", 20, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("A", "B");

            Assert.AreEqual(80, attacker.HP);
            Assert.AreEqual(70, defender.HP);
        }
    }
}