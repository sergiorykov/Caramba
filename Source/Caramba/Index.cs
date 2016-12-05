namespace Caramba
{
    public static class Index
    {
        public static IIndexGenerator Forward(int till) => new ForwardIndexGenerator(till);
        public static IIndexGenerator Random(int till) => new RandomIndexGenerator(till);
    }
}