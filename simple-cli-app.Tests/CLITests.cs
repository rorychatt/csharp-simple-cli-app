using simple_cli_app.Program;
using FluentAssertions;
using static simple_cli_app.Program.App;
using System.Text.Json;

namespace simple_cli_app.Tests;

public class CLITests
{

    private readonly static string currentDir = Directory.GetCurrentDirectory();

    private void RemoveRelativeFile(string url)
    {
        var path = Path.Combine(currentDir, url);
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    [Fact]
    public void EmptyProgramBuilds()
    {
        App app = new();

        app.Should().NotBeNull();
    }

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

    [Fact]
    public void RaiseArgumentException_WhenBadSpecifierRorW()
    {
        App app = new();

        string[] testArgs = ["b", "t"];

        var ex = Assert.Throws<ArgumentException>(() => { App.Main(testArgs); });

        ex.Message.Should().Be("Only r - read and w - write tags are supported");
    }

    [Fact]
    public void WritesEmptyJSON()
    {
        List<ReadableData> readableData = new();
        string url = "example.json";
        string[] testArgs = ["w", url, JsonSerializer.Serialize(readableData)];

        App.Main(testArgs);

        var fullPath = Path.Combine(currentDir, url);
        Path.Exists(fullPath).Should().Be(true);

        RemoveRelativeFile(url);
        //Todo: unneccessary code?
        Path.Exists(fullPath).Should().Be(false);
    }

}