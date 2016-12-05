using System;

namespace Caramba
{
    public class PrefixNameSource : INameSource
    {
        private readonly string _prefix;
        private readonly INameSource _source;

        public PrefixNameSource(string prefix, INameSource source)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                throw new ArgumentNullException(nameof(prefix));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            _prefix = prefix;
            _source = source;
        }

        public string Next()
        {
            return _prefix + _source.Next();
        }
    }
}