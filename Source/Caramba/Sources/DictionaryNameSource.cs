using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Caramba
{
    public enum DictionaryNameSelectionType
    {
        OneByOne = 0,
        Random = 1
    }

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class DictionaryNameSource : INameSource
    {
        private readonly IIndexGenerator _generator;
        private readonly List<string> _names;

        public DictionaryNameSource(IEnumerable<string> names, DictionaryNameSelectionType type)
        {
            _names = new List<string>(names ?? new List<string>());
            if (_names.Count == 0)
            {
                throw new ArgumentNullException(nameof(names));
            }

            _generator = type == DictionaryNameSelectionType.OneByOne 
                ? (IIndexGenerator)new ForwardIndexGenerator(_names.Count) 
                : new RandomIndexGenerator(_names.Count);
        }

        private string DebuggerDisplay =>
            $"Dictionary with {_names} names, like: {string.Join(", ", _names.Take(3))} ...";

        public string Next()
        {
            var index = _generator.Next();
            return _names[index];
        }
    }
}