using MythicLegion;
using NUnit.Framework;
using System;

namespace MythicLegionTests
{
    [TestFixture]
    public class LegionTests
    {
        private Legion legion;

        [SetUp]
        public void Setup()
        {
            legion = new Legion();
        }

        [Test]
        public void Hero_Constructor_ShouldSetNameTypeAndDefaultValues()
        {
            var hero = new Hero("Ares", "Warrior");

            Assert.AreEqual("Ares", hero.Name);
            Assert.AreEqual("Warrior", hero.Type);
            Assert.AreEqual(20, hero.Power);
            Assert.AreEqual(100, hero.Health);
            Assert.IsFalse(hero.IsTrained);
        }

        [Test]
        public void Hero_ToString_ShouldReturnCorrectFormat()
        {
            var hero = new Hero("Ares", "Warrior");
            hero.Power = 30;
            hero.Health = 110;
            hero.IsTrained = true;

            var result = hero.ToString();

            Assert.AreEqual("Ares (Warrior) - Power: 30, Health: 110, Trained: True", result);
        }

        [Test]
        public void GetLegionInfo_ShouldReturnMessage_WhenLegionIsEmpty()
        {
            var result = legion.GetLegionInfo();

            Assert.AreEqual("No heroes in the legion.", result);
        }

        [Test]
        public void Add_ShouldAddHero_WhenHeroIsValid()
        {
            var hero = new Hero("Ares", "Warrior");

            legion.AddHero(hero);

            var info = legion.GetLegionInfo();
            Assert.IsTrue(info.Contains("Ares (Warrior)"));
        }

        [Test]
        public void Add_ShouldThrow_WhenHeroIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => legion.AddHero(null));
        }

        [Test]
        public void Add_ShouldThrow_WhenHeroWithSameNameExists()
        {
            var hero1 = new Hero("Ares", "Warrior");
            var hero2 = new Hero("Ares", "Mage");

            legion.AddHero(hero1);

            Assert.Throws<ArgumentException>(() => legion.AddHero(hero2));
        }

        [Test]
        public void RemoveHero_ShouldReturnTrueAndRemoveHero_WhenHeroExists()
        {
            var hero = new Hero("Zeus", "God");
            legion.AddHero(hero);

            var result = legion.RemoveHero("Zeus");

            Assert.IsTrue(result);
            var info = legion.GetLegionInfo();
            Assert.IsFalse(info.Contains("Zeus"));
        }

        [Test]
        public void RemoveHero_ShouldReturnFalse_WhenHeroDoesNotExist()
        {
            var result = legion.RemoveHero("Unknown");

            Assert.IsFalse(result);
        }

        [Test]
        public void TrainHero_ShouldIncreaseStatsAndMarkTrained_WhenHeroExists()
        {
            var hero = new Hero("Hera", "Goddess");
            legion.AddHero(hero);

            var result = legion.TrainHero("Hera");

            Assert.AreEqual("Hera has been trained.", result);
            Assert.AreEqual(101, hero.Health);
            Assert.AreEqual(30, hero.Power);
            Assert.IsTrue(hero.IsTrained);
        }

        [Test]
        public void TrainHero_ShouldReturnMessage_WhenHeroNotFound()
        {
            var result = legion.TrainHero("Unknown");

            Assert.AreEqual("Hero with name Unknown not found.", result);
        }

        [Test]
        public void TrainHero_ShouldAffectOnlyTargetHero()
        {
            var hero1 = new Hero("Hera", "Goddess");
            var hero2 = new Hero("Athena", "Goddess");
            legion.AddHero(hero1);
            legion.AddHero(hero2);

            legion.TrainHero("Hera");

            Assert.IsTrue(hero1.IsTrained);
            Assert.IsFalse(hero2.IsTrained);
            Assert.AreEqual(101, hero1.Health);
            Assert.AreEqual(20, hero2.Health);
        }

        [Test]
        public void GetLegionInfo_ShouldReturnAllHeroesInfo_WhenLegionHasHeroes()
        {
            var hero1 = new Hero("Ares", "Warrior");
            var hero2 = new Hero("Zeus", "God");
            legion.AddHero(hero1);
            legion.AddHero(hero2);

            var result = legion.GetLegionInfo();

            Assert.IsTrue(result.Contains("Ares (Warrior)"));
            Assert.IsTrue(result.Contains("Zeus (God)"));
        }

        [Test]
        public void AddHero_ShouldNotAddHero_WhenInternalListMethodIsWrong()
        {
            var hero = new Hero("Ares", "Warrior");

            legion.AddHero(hero);

            var result = legion.GetLegionInfo();

            Assert.AreEqual("No heroes in the legion.", result);
        }

    }
}
