using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Linq;

namespace DatabaseExtended.Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        private Person[] people;

        [SetUp]
        public void Setup()
        {
            people = new Person[]
            {
                new Person(1, "Gosho"),
                new Person(2, "Pesho"),
                new Person(3, "Maria")
            };

            database = new Database(people);
        }

        // ---------- CONSTRUCTOR TESTS ----------

        [Test]
        public void ConstructorShouldSetCorrectCount()
        {
            Assert.AreEqual(people.Length, database.Count);
        }

        [Test]
        public void ConstructorShouldThrowWhenMoreThan16People()
        {
            Person[] tooMany = Enumerable.Range(1, 17)
                .Select(i => new Person(i, $"User{i}"))
                .ToArray();

            Assert.Throws<ArgumentException>(() => new Database(tooMany));
        }

        // ---------- ADD TESTS ----------

        [Test]
        public void AddShouldIncreaseCount()
        {
            var db = new Database();
            db.Add(new Person(1, "Test"));

            Assert.AreEqual(1, db.Count);
        }

        [Test]
        public void AddShouldThrowWhenCapacityExceeded()
        {
            var fullDb = new Database(
                Enumerable.Range(1, 16)
                .Select(i => new Person(i, $"User{i}"))
                .ToArray());

            Assert.Throws<InvalidOperationException>(() =>
                fullDb.Add(new Person(17, "Overflow")));
        }

        [Test]
        public void AddShouldThrowWhenUsernameExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
                database.Add(new Person(99, "Gosho")));
        }

        [Test]
        public void AddShouldThrowWhenIdExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
                database.Add(new Person(1, "NewUser")));
        }

        // ---------- REMOVE TESTS ----------

        [Test]
        public void RemoveShouldDecreaseCount()
        {
            database.Remove();
            Assert.AreEqual(2, database.Count);
        }

        [Test]
        public void RemoveShouldThrowWhenEmpty()
        {
            var db = new Database();
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        // ---------- FindByUsername TESTS ----------

        [Test]
        public void FindByUsernameShouldReturnCorrectPerson()
        {
            var person = database.FindByUsername("Gosho");
            Assert.AreEqual("Gosho", person.UserName);
        }

        [Test]
        public void FindByUsernameShouldThrowWhenNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
                database.FindByUsername(null));
        }

        [Test]
        public void FindByUsernameShouldThrowWhenUserNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
                database.FindByUsername("Unknown"));
        }

        // ---------- FindById TESTS ----------

        [Test]
        public void FindByIdShouldReturnCorrectPerson()
        {
            var person = database.FindById(1);
            Assert.AreEqual(1, person.Id);
        }

        [Test]
        public void FindByIdShouldThrowWhenNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                database.FindById(-1));
        }

        [Test]
        public void FindByIdShouldThrowWhenUserNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
                database.FindById(999));
        }
    }
}
