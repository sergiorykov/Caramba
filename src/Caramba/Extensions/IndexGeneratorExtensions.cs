namespace Caramba
{
    public static class IndexGeneratorExtensions
    {
        public static IIndexGenerator WithOffset(this IIndexGenerator generator, int offset)
            => new OffsetIndexGenerator(offset, generator);
    }
}