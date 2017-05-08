using System;

namespace Caramba
{
    public class NumberNameSource : INameSource
    {
        private readonly IIndexGenerator _generator;

        public NumberNameSource(IIndexGenerator generator)
        {
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));

            _generator = generator;
        }

        public string Next()
        {
            var index = _generator.Next();
            return index.ToString();
        }

        public INameSource WithPadding(int padding)
        {
            return new PaddingNumberNameSource(_generator, padding);
        }
    }
}