using System.Collections.Generic;
using System.Linq;

namespace Caramba
{
    public static class Name
    {
        public static INameSource From(string value) => new ConstStringNameSource(value);

        public static NumberNameSource From(IIndexGenerator generator) => new NumberNameSource(generator);

        public static INameSource Range(params string[] values) => new DictionaryNameSource(values.ToList(), DictionaryNameSelectionType.OneByOne);
        public static INameSource Range(IEnumerable<string> values) => new DictionaryNameSource(values, DictionaryNameSelectionType.OneByOne);

        public static INameSource Random(params string[] values) => new DictionaryNameSource(values.ToList(), DictionaryNameSelectionType.Random);
        public static INameSource Random(IEnumerable<string> values) => new DictionaryNameSource(values, DictionaryNameSelectionType.Random);

        public static INameSource Combined(params INameSource[] sources) => new CombinedNameSource(sources);
        public static INameSource Combined(string separator, params INameSource[] sources) => new CombinedNameSource(sources, separator);
    }
}