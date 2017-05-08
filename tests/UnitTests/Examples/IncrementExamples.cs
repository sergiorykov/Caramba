using Caramba;
using Shouldly;
using Xunit;

namespace UnitTests.Examples
{
    public class IncrementExamples
    {
        [Fact]
        public void CompletePhoneNumber()
        {
            var source = Name.From(Index.Range(10, 100000)).WithPadding(5);

            var sample = source.Next();
            sample.ShouldNotBeNullOrEmpty();
        }
    }
}