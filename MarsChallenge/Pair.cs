

namespace MarsChallenge
{
    class Pair
    {
        readonly public int A;
        readonly public int B;
        readonly public int Sum;
        readonly public int Mul;

        public Pair(int a, int b)
        {
            A = a;
            B = b;
            Sum = a + b;
            Mul = a * b;
        }
    }
}