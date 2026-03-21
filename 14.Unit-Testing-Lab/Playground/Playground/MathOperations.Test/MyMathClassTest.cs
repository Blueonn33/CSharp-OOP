namespace MathOperations.Test
{
    public class MyMathClassTest
    {
        [Test]
        public void SumShouldReturnCorrectValue()
        {
            var mathClass = new MyMathClass();
            var result = mathClass.Sum(2, 5);

            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void ProductShouldReturnCorrectValue()
        {
            var mathClass = new MyMathClass();
            var result = mathClass.Product(2, 5);

            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void PowerShouldReturnCorrectValue()
        {
            var mathClass = new MyMathClass();
            var result = mathClass.Power(2, 3);

            Assert.That(result, Is.EqualTo(8));
        }
    }
}
