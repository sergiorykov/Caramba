using System.Collections.Generic;

namespace Caramba
{
    public static class NameSourceExtensions
    {
        public static INameSource WithPrefix(this INameSource source, string prefix) => new PrefixNameSource(prefix, source);
        public static INameSource WithSuffix(this INameSource source, string suffix) => new SuffixNameSource(suffix, source);

        public static INameSource Then(this INameSource source, string separator, params INameSource[] otherSources)
        {
            var sources = new List<INameSource> { source };
            sources.AddRange(otherSources);

            return new CombinedNameSource(sources, separator);
        }

        public static INameSource Then(this INameSource source, string separator)
        {
            var sources = new List<INameSource> {source, Name.From(separator)};
            return new CombinedNameSource(sources, separator);
        }

        public static INameSource Then(this INameSource source, IIndexGenerator index)
        {
            var sources = new List<INameSource> { source, Name.From(index) };
            return new CombinedNameSource(sources);
        }

        public static INameSource Then(this INameSource source, string separator, IIndexGenerator index)
        {
            var sources = new List<INameSource> { source, Name.From(index) };
            return new CombinedNameSource(sources, separator);
        }

        public static INameSource Then(this INameSource source, params INameSource[] otherSources)
        {
            var sources = new List<INameSource> { source };
            sources.AddRange(otherSources);

            return new CombinedNameSource(sources);
        }

        public static INameSource Or(this INameSource source, INameSource otherSource) => 
            new OneOfNameSource(new List<INameSource> {source, otherSource});
    }
}