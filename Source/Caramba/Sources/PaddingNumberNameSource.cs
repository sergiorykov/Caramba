using System;

namespace Caramba
{
    public class PaddingNumberNameSource : INameSource
    {
        private readonly IIndexGenerator _generator;
        private readonly string _paddingFormat;

        public PaddingNumberNameSource(IIndexGenerator generator, int padding)
        {
            if (generator == null)
                throw new ArgumentNullException(nameof(generator));

            if ((padding < 1) || (padding > 100))
                throw new ArgumentOutOfRangeException(nameof(padding));

            _generator = generator;
            _paddingFormat = $"D{padding}";

            Padding = padding;
        }

        public int Padding { get; private set; }

        public string Next()
        {
            var index = _generator.Next();
            return index.ToString(_paddingFormat);
        }
    }
}