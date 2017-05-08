using Caramba;
using Shouldly;
using Xunit;

namespace UnitTests.Examples
{
    public class PhoneNumberExamples
    {
        [Fact]
        public void CompletePhoneNumber()
        {
            var phoneNumber = BuiltinNames.PhoneNumber("+7 926 00", 5);

            var sample = phoneNumber.Next();
            sample.ShouldNotBeNullOrEmpty();
        }
    }
}