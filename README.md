# ![Caramba](https://github.com/sergiorykov/Caramba/blob/master/docs/carambola64.png) Caramba

[![NuGet Badge](https://buildstats.info/nuget/Caramba)](https://www.nuget.org/packages/Caramba/) [![License MIT](https://img.shields.io/badge/license-MIT-green.svg)](https://opensource.org/licenses/MIT) [![Build status](https://ci.appveyor.com/api/projects/status/h9jq50928otg2dkw?svg=true)](https://ci.appveyor.com/project/sergiorykov/caramba)

Name generator for unit tests. 

It allows to generate any pseudo natural string values for your unit tests/specs. Especially it'll be extremely useful for load tests when you need to fill your database with data looks like real one. See examples to get an idea of the library.

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
var phoneNumber = BuiltinNames.PhoneNumber("+7 926 ", 7);
var sample = phoneNumber.Next();
Console.WriteLine(sample); // +7 926 0012345
```

It has pretty simple implementation
``` csharp
public static class BuiltinNames
{
    public static INameSource PhoneNumber(string prefix, int digits)
    {
        if ((digits <= 0) || (digits > 20))
            throw new ArgumentOutOfRangeException(nameof(digits), "should be less then or equal to 20");

        int till = (int)Math.Pow(10, digits);
        return Name.From(prefix)
            .Then(Name.From(Index.Forward(till)).WithPadding(digits));
    }
}
```

### How to generate email
``` csharp
var email = Name.Mix("Jake", "John", "Lisa")
    .Then(Name.From(Index.Forward(1000)).WithPadding(4))
    .Then("@")
    .Then(Name.Mix("hotmail.com", "google.com", "yahoo.com"));
var sample = email.Next();
```

License
-------

All contents of this package are licensed under the [MIT license](https://opensource.org/licenses/MIT).