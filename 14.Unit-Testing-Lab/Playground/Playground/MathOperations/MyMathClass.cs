namespace MathOperations
{
    public class MyMathClass
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }

        public int Product(int x, int y)
        {
            return x * y;
        }

        public int Powe(int x, int y)
        {
            var result = 1;

            for (int i = 0; i < y; i++)
            {
                result *= x;
            }

            return result;
        }
    }
}
