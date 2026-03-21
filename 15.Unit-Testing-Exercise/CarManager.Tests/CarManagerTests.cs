namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Suzuki", "Swift", 10, 100);
        }

        [Test]
        public void CarShouldBeCreatedCorrectly()
        {
            string expectedMake = "Suzuki";
            string expectedModel = "Swift";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void CarShouldBeCreatedWithEmptyFuelAmount()
        {
            double expectedFuelAmount = 0;
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }
    }
}