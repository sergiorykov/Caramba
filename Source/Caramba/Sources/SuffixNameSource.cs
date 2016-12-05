using System;

namespace Caramba
{
    public class SuffixNameSource : INameSource
    {
        private readonly string _suffix;
        private readonly INameSource _source;

        public SuffixNameSource(string suffix, INameSource source)
        {
            if (string.IsNullOrEmpty(suffix))
            {
                throw new ArgumentNullException(nameof(suffix));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            _suffix = suffix;
            _source = source;
        }

        public string Next()
        {
            return _source.Next() + _suffix;
        }
    }
}