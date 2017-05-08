using System;

namespace Caramba
{
    public static class Index
    {
        public static IIndexGenerator Range(int till) => new RangeIndexGenerator(till);

        public static IIndexGenerator Range(int from, int till)
        {
            if (from >= till)
                throw new ArgumentException("from should be less then till");

            return new OffsetIndexGenerator(from, new RangeIndexGenerator(till - from));
        }

        public static IIndexGenerator Random(int till) => new RandomIndexGenerator(till);

        public static IIndexGenerator Random(int from, int till)
        {
            if (from >= till)
                throw new ArgumentException("from should be less then till");

            return new OffsetIndexGenerator(from, new RandomIndexGenerator(till - from));
        }
    }
}