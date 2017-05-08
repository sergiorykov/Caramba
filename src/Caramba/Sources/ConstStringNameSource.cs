using System;
using System.Diagnostics;

namespace Caramba
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class ConstStringNameSource : INameSource
    {
        private readonly string _value;

        public ConstStringNameSource(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            _value = value;
        }

        private string DebuggerDisplay => $"Const string '{_value}'";

        public string Next()
        {
            return _value;
        }
    }
}