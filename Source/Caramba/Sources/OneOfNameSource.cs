using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Caramba
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class OneOfNameSource : INameSource
    {
        private readonly IIndexGenerator _generator;
        private readonly List<INameSource> _sources;

        public OneOfNameSource(IEnumerable<INameSource> sources)
        {
            _sources = new List<INameSource>(sources ?? new List<INameSource>());
            if (_sources.Count == 0)
            {
                throw new ArgumentNullException(nameof(sources));
            }

            _generator = Index.Random(_sources.Count);
        }

        private string DebuggerDisplay => $"One of {string.Join(" or ", _sources)}";

        public string Next()
        {
            return _sources[_generator.Next()].Next();
        }
    }
}