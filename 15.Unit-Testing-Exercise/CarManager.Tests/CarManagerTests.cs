using System;

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
            double expectedFuelConsumption = 10;
            double expectedFuelCapacity = 100;
            //double expectedFuelAmount = 0;

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
            //Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void CarShouldBeCreatedWithEmptyFuelAmount()
        {
            double expectedFuelAmount = 0;
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarMakeShouldThrowExceptionWhenValueIsNullOrEmpty(string make)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Car(make, "Suzuki", 10, 100));
            Assert.AreEqual("Make cannot be null or empty!", exception.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarModelShouldThrowExceptionWhenValueIsNullOrEmpty(string model)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Car("Suzuki", model, 10, 100));
            Assert.AreEqual("Model cannot be null or empty!", exception.Message);
        }

        [TestCase(-17)]
        [TestCase(0)]
        public void CarFuelConsumptionShouldThrowExceptionWhenValueIsNegativeOrZero(double fuelConsumption)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Car("Suzuki", "Swift", fuelConsumption, 100));
            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }

        [TestCase(-17)]
        public void CarFuelAmountShouldThrowExceptionWhenValueIsNegative(double fuelAmount)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new Car("Suzuki", "Swift", 10, fuelAmount));
            Assert.AreEqual("Fuel amount cannot be negative!", exception.Message);
        }
    }
}