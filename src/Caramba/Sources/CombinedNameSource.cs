using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Caramba
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class CombinedNameSource : INameSource
    {
        private readonly string _separator;
        private readonly List<INameSource> _sources;

        public CombinedNameSource(IEnumerable<INameSource> sources, string separator = "")
        {
            _separator = separator ?? "";
            if (sources == null)
            {
                throw new ArgumentNullException(nameof(sources));
            }
            
            _sources = new List<INameSource>(sources);

            if (_sources.Count == 0)
            {
                throw new ArgumentNullException(nameof(sources));
            }
        }

        private string DebuggerDisplay => $"Combined of {string.Join(" and ", _sources)}" 
            + (string.IsNullOrEmpty(_separator) ? "" : $" with separator '{_separator}'");

        public string Next()
        {
            return string.Join(_separator, _sources.Select(x => x.Next()));
        }
    }
}