# FkThat.Tdd

[![Build Status](https://dev.azure.com/FkThat/CI/_apis/build/status/Tdd?branchName=develop)](https://dev.azure.com/FkThat/CI/_build/latest?definitionId=44&branchName=develop)
[![Azure DevOps tests (develop)](https://img.shields.io/azure-devops/tests/FkThat/CI/44/develop)](https://dev.azure.com/FkThat/CI/_build/latest?definitionId=44&branchName=develop)
[![Azure DevOps coverage (develop)](https://img.shields.io/azure-devops/coverage/FkThat/CI/44/develop)](https://dev.azure.com/FkThat/CI/_build/latest?definitionId=44&branchName=develop)

[![MyGet](https://img.shields.io/myget/fkthat/v/FkThat.Tdd?label=FkThat.Tdd)](https://www.myget.org/feed/fkthat/package/nuget/FkThat.Tdd)
[![MyGet](https://img.shields.io/myget/fkthat/v/FkThat.Tdd.Abstractions?label=FkThat.Tdd.Abstractions)](https://www.myget.org/feed/fkthat/package/nuget/FkThat.Tdd.Abstractions)
[![MyGet](https://img.shields.io/myget/fkthat/v/FkThat.Tdd.DependencyInjection?label=FkThat.Tdd.DependencyInjection)](https://www.myget.org/feed/fkthat/package/nuget/FkThat.Tdd.DependencyInjection)

Simple wrappers helping to write test-friendly code.

## Demo

```csharp
// register components
services.AddTdd();
```


```csharp
/// <summary>
/// Testee class.
/// </summary>
public class Foo
{
    private readonly ISystemClock _clock;
    private readonly IGuidGen _guidGen;
    private readonly IRandom _random;
    private readonly IConsole _console;

    public Foo(ISystemClock clock, IGuidGen guidGen, IRandom random, IConsole console)
    {
        _clock = clock;
        _guidGen = guidGen;
        _random = random;
        _console = console;
    }

    public void Bar()
    {
        var stdout = _console.Out;
        stdout.WriteLine(_clock.UtcNow.ToString("G", CultureInfo.InvariantCulture));
        stdout.WriteLine(_guidGen.NewGuid());
        stdout.WriteLine(_random.Next(16));
    }
}
```

```csharp
/// <summary>
/// Test Bar method.
///</summary>
[Fact]
public void Bar_ShouldWriteData()
{
    var clock = A.Fake<ISystemClock>();
    var guidGen = A.Fake<IGuidGen>();
    var random = A.Fake<IRandom>();
    var console = A.Fake<IConsole>();

    A.CallTo(() => clock.UtcNow).Returns(
        new DateTimeOffset(1973, 8, 9, 10, 17, 42, TimeSpan.Zero));

    A.CallTo(() => guidGen.NewGuid()).Returns(
        new Guid("{8AB11641-ACD5-490C-8587-B59B82C91C0D}"));

    A.CallTo(() => random.Next(16)).Returns(7);

    StringWriter writer = new();
    A.CallTo(() => console.Out).Returns(writer);

    Foo testee = new(clock, guidGen, random, console);
    testee.Bar();

    writer.ToString().Should().Be(
        "08/09/1973 10:17:42" + Environment.NewLine +
        "8ab11641-acd5-490c-8587-b59b82c91c0d" + Environment.NewLine +
        "7" + Environment.NewLine);
}
```
