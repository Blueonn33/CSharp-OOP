namespace MathOperations.Test
{
    [TestFixture]
    public class MyMathClassTest
    {
        private MyMathClass mathClass;

        [SetUp]
        public void SetUpMathClass()
        {
            this.mathClass = new MyMathClass();
        }

        [Test]
        public void SumShouldReturnCorrectValue()
        {
            var result = mathClass.Sum(2, 5);

            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void ProductShouldReturnCorrectValue()
        {
            var result = mathClass.Product(2, 5);

            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void PowerShouldReturnCorrectValue()
        {
            var result = mathClass.Power(2, 3);

            Assert.That(result, Is.EqualTo(8));
        }
    }
}
