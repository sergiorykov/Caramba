using Caramba;
using Shouldly;
using Xunit;

namespace UnitTests.Builtin
{
    public class ValidPhoneNumber
    {
        public ValidPhoneNumber()
        {
            _nameSource = BuiltinNames.PhoneNumber(Prefix, Digits);
        }

        private const string Prefix = "+7 926 00";
        private const int Digits = 4;

        private readonly INameSource _nameSource;

        [Fact]
        public void Has_Expected_Length()
        {
            var name = _nameSource.Next();
            name.Length.ShouldBe(Prefix.Length + Digits);
        }

        [Fact]
        public void Starts_With_Prefix()
        {
            var name = _nameSource.Next();
            name.ShouldStartWith(Prefix);
        }
    }
}