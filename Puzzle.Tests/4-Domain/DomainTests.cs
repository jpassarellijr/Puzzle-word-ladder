using Bogus;
using FluentAssertions;
using Puzzle.Domain.Enumerations;
using Puzzle.Domain.Models;
using Puzzle.Domain.Services;
using Xunit;

[Trait("Puzzle", "Domain")]
public class DomainTests : IClassFixture<PuzzleFixture>
{
    /// <summary>
    /// The fixture
    /// </summary>
    PuzzleFixture fixture;

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainTests"/> class.
    /// </summary>
    /// <param name="fixture">The fixture.</param>
    public DomainTests(PuzzleFixture fixture)
    {
        this.fixture = fixture;
    }

    /// <summary>
    /// Puzzles the services API generate word ladder.
    /// </summary>
    [Fact(DisplayName = "Generate Word Ladder successfully")]
    public void Puzzle_Domain_GenerateWordLadderSuccessfully()
    {
        // Arrange
        var faker = new Faker("en");

        var request = new WordLadder
        {
            StartWord = new Word
            {
                Value = "POOL",
                AllowedWords = fixture.dictionary,
                Type = faker.PickRandom<WordType>()
            },
            EndWord = new Word
            {
                Value = "PONY",
                AllowedWords = fixture.dictionary,
                Type = faker.PickRandom<WordType>()
            },
            AnswerFileName = new Answer
            {
                Extension = faker.System.CommonFileType(),
                FileName = faker.System.CommonFileName(),
                Path = faker.System.DirectoryPath()
            },
            Dictionary = new WordDictionary
            {
                Default = faker.Random.Word(),
                File = faker.Random.Bytes(100)
            },
        };

        //Act
        var result = new WordLadderService().GenerateWordLadder(request);

        //Assert
        result.Should().NotBeNull();

    }
    /// <summary>
    /// Puzzles the services API generate word ladder.
    /// </summary>
    [Fact(DisplayName = "Generate Word Ladder")]
    public void Puzzle_Domain_GenerateWordLadder()
    {
        // Arrange
        var faker = new Faker("en");

        var request = new WordLadder
        {
            StartWord = new Word
            {
                Value = faker.PickRandom(fixture.dictionary),
                AllowedWords = fixture.dictionary,
                Type = faker.PickRandom<WordType>()
            },
            EndWord = new Word
            {
                Value = faker.PickRandom(fixture.dictionary),
                AllowedWords = fixture.dictionary,
                Type = faker.PickRandom<WordType>()
            },
            AnswerFileName = new Answer
            {
                Extension = faker.System.CommonFileType(),
                FileName = faker.System.CommonFileName(),
                Path = faker.System.DirectoryPath()
            },
            Dictionary = new WordDictionary
            {
                Default = faker.Random.Word(),
                File = faker.Random.Bytes(100)
            },
        };

        //Act
        var result = new WordLadderService().GenerateWordLadder(request);

        //Assert
        result.Should().NotBeNull();

    }
}

