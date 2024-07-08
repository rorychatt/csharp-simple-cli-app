using simple_cli_app.Program;
using FluentAssertions;

namespace simple_cli_app.Tests;

public class CLITests
{
    [Fact]
    public void RaiseArgumentException_WhenNoArguments()
    {
        App app = new();

        var ex = Assert.Throws<ArgumentException>(() => { App.Main([]); });

        ex.Message.Should().Be("Please provide some arguments, like 'read data.json'");
    }

    [Fact]
    public void RaiseArgumentException_When1Argument()
    {
        App app = new();

        var ex = Assert.Throws<ArgumentException>(() => { App.Main(["hahahaha"]); });

        ex.Message.Should().Be("Please provide name of the .JSON file to read or write to");
    }


}