using FluentAssertions;
using Puzzle.ConsoleApp.Helper;
using Xunit;

[Trait("Puzzle", "Console")]
public class ConsoleAppTests : IClassFixture<PuzzleFixture>
{
    /// <summary>
    /// The fixture
    /// </summary>
    PuzzleFixture fixture;

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainTests"/> class.
    /// </summary>
    /// <param name="fixture">The fixture.</param>
    public ConsoleAppTests(PuzzleFixture fixture)
    {
        this.fixture = fixture;
    }

    /// <summary>
    /// Puzzles the console new file.
    /// </summary>
    [Fact(DisplayName = "Use a new file")]
    public void Puzzle_Console_NewFile()
    {
        // Arrange

        //Act
        var result = TextFile.NewFile(fixture.path);

        //Assert
        result.Should().NotBeNull();

    }

    /// <summary>
    /// Puzzles the console store data in list.
    /// </summary>
    [Fact(DisplayName = "Store Data in a List")]
    public void Puzzle_Console_StoreDataInList()
    {
        // Arrange

        //Act
        var result = TextFile.StoreDataInList(fixture.dicFile);

        //Assert
        result.Should().NotBeNull();

    }

}

