using System;
using System.Diagnostics;
using System.Threading;

namespace Caramba
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class RangeIndexGenerator : IIndexGenerator
    {
        private int _current = -1;

        public RangeIndexGenerator(int till)
        {
            if (till <= 0)
                throw new AggregateException("till should be greater then zero");

            Till = till;
        }


        public int Till { get; }

        private string DebuggerDisplay => $"Range numbers from 0 to {Till}";

        public int Next()
        {
            return Interlocked.Increment(ref _current)%Till;
        }
    }
}