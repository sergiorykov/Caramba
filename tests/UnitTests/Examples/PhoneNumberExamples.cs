using System;
using Caramba;
using Shouldly;
using Xunit;

namespace UnitTests.Builtin
{
    public static class BuiltinNames
    {
        public static INameSource PhoneNumber(string prefix, int digits)
        {
            if ((digits <= 0) || (digits > 16))
                throw new ArgumentOutOfRangeException(nameof(digits), "should be less then or equal to 16");

            int till = (int)Math.Pow(10, digits);
            return Name.From(prefix)
                .Then(Name.From(Index.Range(till)).WithPadding(digits));
        }
    }

    public class PhoneNumberExamples
    {
        public PhoneNumberExamples()
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