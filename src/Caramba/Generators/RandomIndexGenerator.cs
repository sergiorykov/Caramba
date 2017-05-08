using System;

namespace Caramba
{
    public class RandomIndexGenerator : IIndexGenerator
    {
        private readonly Random _random;

        public RandomIndexGenerator(int till)
        {
            if (till <= 0)
                throw new ArgumentOutOfRangeException(nameof(till), "till should be greater then zero");

            Till = till;
            _random = new Random(Environment.TickCount);
        }

        public int Till { get; }

        public int Next()
        {
            return _random.Next(Till);
        }
    }
}