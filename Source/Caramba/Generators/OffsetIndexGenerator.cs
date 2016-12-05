namespace Caramba
{
    public class OffsetIndexGenerator : IIndexGenerator
    {
        private readonly IIndexGenerator _generator;
        private readonly int _offset;

        public OffsetIndexGenerator(int offset, IIndexGenerator generator)
        {
            _offset = offset;
            _generator = generator;
        }

        public int Next()
        {
            return _offset + _generator.Next();
        }
    }
}