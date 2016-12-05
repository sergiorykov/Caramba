# Caramba
Name generator for unit tests. 

It allows to provide simple rules to generate any pseudo natural values for your unit tests/specs.

It's a great companion to [AutoFixture](https://github.com/AutoFixture/AutoFixture).


## Examples

### How to generate full person name
Let's say we want enormous number of full person names in form of `<title> <firstname>12 <lastname>034`. 

``` csharp
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
```

### How to generate phone numbers

``` csharp
var phoneNumber = BuiltinNames.PhoneNumber("+7 926 00", 5);
var sample = phoneNumber.Next();
```

It has pretty simple implementation
``` csharp
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
```