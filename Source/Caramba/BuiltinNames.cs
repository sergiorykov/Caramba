using System;

namespace Caramba
{
    public static class BuiltinNames
    {
        public static INameSource PhoneNumber(string prefix, int digits)
        {
            if ((digits <= 0) || (digits > 12))
                throw new ArgumentOutOfRangeException(nameof(digits), "should be less then or equal to 12");

            int till = (int)Math.Pow(10, digits);
            return Name.From(prefix)
                .Then(Name.From(Index.Forward(till)).WithPadding(5));
        }
    }
}