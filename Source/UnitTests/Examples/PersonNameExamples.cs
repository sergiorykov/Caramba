using System.Linq;
using Caramba;
using Shouldly;
using Xunit;

namespace UnitTests.Examples
{
    public class PersonNameExamples
    {
        [Fact]
        public void CompletePersonName()
        {
            var ladyName = Name.From("Jill", "Janette", "Jane", "Jinny");
            var ladyTitle = Name.Mix("mrs", "ms", "dr");

            var gentelmanName = Name.From("John", "Jack", "Jamey", "Joshua");
            var gentelmanTitle = Name.Mix("mr", "dr", "sir", "colonel");

            var lady = ladyTitle
                .Then(" ")
                .Then(ladyName)
                .Then(Name.From(Index.Forward(50)));

            var gentelman = gentelmanTitle
                .Then(" ")
                .Then(gentelmanName)
                .Then(Name.From(Index.Forward(50)));

            var firstName = lady.Or(gentelman);

            var lastName = Name.Mix("Nixon", "Obama", "Bush")
                .Then(Name.From(Index.Forward(100)).WithPadding(3));

            var personName = firstName.Then(" ", lastName);

            var names = Enumerable.Range(0, 1000)
                .Select(_ => personName.Next())
                .ToList();

            names.Count.ShouldBe(1000);

            var sample = personName.Next();
            sample.ShouldNotBeNullOrEmpty();
        }
    }
}