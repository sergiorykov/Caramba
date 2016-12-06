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
            var ladyName = Name.Range("Jill", "Janette", "Jane", "Jinny");
            var ladyTitle = Name.Random("mrs", "ms", "dr");

            var gentlemanName = Name.Range("John", "Jack", "Jamey", "Joshua");
            var gentlemanTitle = Name.Random("mr", "dr", "sir", "colonel");

            var lady = ladyTitle
                .Then(" ")
                .Then(ladyName)
                .Then(Name.From(Index.Range(50)));

            var gentleman = gentlemanTitle
                .Then(" ")
                .Then(gentlemanName)
                .Then(Name.From(Index.Range(50)));

            var firstName = lady.Or(gentleman);

            var lastName = Name.Random("Nixon", "Obama", "Bush")
                .Then(Name.From(Index.Range(100)).WithPadding(3));

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