using System.Collections.Generic;
using System.Linq;

namespace Caramba
{
    public static class Name
    {
        public static NumberNameSource From(IIndexGenerator generator) => new NumberNameSource(generator);
        public static INameSource From(string value) => new ConstStringNameSource(value);
        public static INameSource From(params string[] values) => new DictionaryNameSource(values.ToList(), DictionaryNameSelectionType.OneByOne);
        public static INameSource From(IEnumerable<string> values) => new DictionaryNameSource(values, DictionaryNameSelectionType.OneByOne);

        public static INameSource Mix(params string[] values) => new DictionaryNameSource(values.ToList(), DictionaryNameSelectionType.Random);
        public static INameSource Mix(IEnumerable<string> values) => new DictionaryNameSource(values, DictionaryNameSelectionType.Random);

        public static INameSource Combined(params INameSource[] sources) => new CombinedNameSource(sources);
        public static INameSource Combined(string separator, params INameSource[] sources) => new CombinedNameSource(sources, separator);
    }
}