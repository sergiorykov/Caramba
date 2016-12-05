using System;
using System.Diagnostics;
using System.Threading;

namespace Caramba
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class ForwardIndexGenerator : IIndexGenerator
    {
        private readonly int _till;
        private int _current;

        public ForwardIndexGenerator(int till)
        {
            if (till == 0)
                throw new AggregateException("till should be greater then zero");

            _till = till;
            _current = 0;
        }

        private string DebuggerDisplay => $"Forward numbers from 0 to {_till}";

        public int Next()
        {
            return Interlocked.Increment(ref _current)%_till;
        }
    }
}