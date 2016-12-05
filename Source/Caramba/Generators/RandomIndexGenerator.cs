using System;

namespace Caramba
{
    public class RandomIndexGenerator : IIndexGenerator
    {
        private readonly Random _random;
        private readonly int _till;

        public RandomIndexGenerator(int till)
        {
            if (till <= 0)
                throw new ArgumentOutOfRangeException(nameof(till), "till should be greater then zero");

            _till = till;
            _random = new Random(Environment.TickCount);
        }

        public int Next()
        {
            return _random.Next(_till);
        }
    }
}