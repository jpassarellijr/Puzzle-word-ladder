using FluentAssertions;
using Puzzle.Infra.Data.Services;
using Xunit;

[Trait("Puzzle", "Infra_Data")]
public class InfraDataTests
{

    /// <summary>
    /// Puzzles get word dictionary.
    /// </summary>
    [Fact(DisplayName = "Get Word Dictionary")]
    public void Puzzle_Infra_Data_GetWordDictionary()
    {
        // Arrange

        //Act
        var result = new WordDictionaryServiceApi().GetDefault();

        //Assert
        result.Should().NotBeNull();
    }
}

