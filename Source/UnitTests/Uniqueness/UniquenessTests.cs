using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caramba;
using Shouldly;
using Xunit;

namespace UnitTests.Uniqueness
{
    public class UniquenessTests
    {
        [Fact]
        public void PersonName_GenerateWithCapacity_NoDuplicates()
        {
            const int Tests = 10;
            const int Capacity = 1000;

            Parallel.ForEach(
                Enumerable.Range(0, Tests),
                () => new Dictionary<int, Duplicate>(Tests), (test, state, results) =>
                {
                    var foundDuplicate = FirstDuplicate(CreatePersonName(Capacity), Capacity);
                    if (foundDuplicate.HasValue)
                    {
                        results.Add(test, foundDuplicate.Value);
                    }

                    return results;
                }, failures =>
                {
                    var whatFailed = failures
                        .Select(failure => $"Failed test #{failure.Key}: {failure.Value}")
                        .ToList();

                    failures.Count.ShouldBe(0,  $"Failed #{failures.Count} tests:{Environment.NewLine}{string.Join(Environment.NewLine, whatFailed)}");
                });
        }

        private struct Duplicate
        {
            public string Value { get; set; }
            public int FirstCycle { get; set; }
            public int LastCycle { get; set; }

            public override string ToString()
            {
                return $"{nameof(Value)}: {Value}, {nameof(FirstCycle)}: {FirstCycle}, {nameof(LastCycle)}: {LastCycle}";
            }
        }
        
        private static Duplicate? FirstDuplicate(INameSource source, int cycles)
        {
            var results = new Dictionary<string, int>();
            foreach (var cycle in Enumerable.Range(0, cycles))
            {
                var name = source.Next();
                if (results.ContainsKey(name))
                {
                    return new Duplicate
                    {
                        Value = name,
                        FirstCycle = results[name],
                        LastCycle = cycle
                    };
                }

                results.Add(name, cycle);
            }

            return null;
        }

        private static INameSource CreatePersonName(int uniquenessCapacity)
        {
            var ladyName = Name.Range("Jill", "Janette", "Jane", "Jinny");
            var ladyTitle = Name.Random("mrs", "ms", "dr");

            var gentlemanName = Name.Range("John", "Jack", "Jamey", "Joshua");
            var gentlemanTitle = Name.Random("mr", "dr", "sir", "colonel");

            var lady = ladyTitle
                .Then(" ")
                .Then(ladyName)
                .Then(Name.From(Index.Range(uniquenessCapacity)));

            var gentleman = gentlemanTitle
                .Then(" ")
                .Then(gentlemanName)
                .Then(Name.From(Index.Range(uniquenessCapacity)));

            var firstName = lady.Or(gentleman);

            var lastName = Name.Random("Nixon", "Obama", "Bush")
                .Then(Name.From(Index.Range(uniquenessCapacity)).WithPadding((int)Math.Log10(uniquenessCapacity) + 1));

            var personName = firstName.Then(" ", lastName);
            return personName;
        }
    }
}