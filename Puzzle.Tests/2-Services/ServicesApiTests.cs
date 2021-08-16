using Bogus;
using FluentAssertions;
using Moq;
using Puzzle.Application.Interfaces;
using Puzzle.Application.ViewModels;
using Puzzle.Domain.Enumerations;
using Puzzle.Services.Api.Controllers;
using Xunit;

[Trait("Puzzle", "Services")]
public class ServicesApiTests : IClassFixture<PuzzleFixture>
{
    /// <summary>
    /// The fixture
    /// </summary>
    PuzzleFixture fixture;

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainTests"/> class.
    /// </summary>
    /// <param name="fixture">The fixture.</param>
    public ServicesApiTests(PuzzleFixture fixture)
    {
        this.fixture = fixture;
    }

    /// <summary>
    /// The mock word ladder
    /// </summary>
    public Mock<IWordLadderService> mockWordLadder = new Mock<IWordLadderService>();

    /// <summary>
    /// The mock word dictionary
    /// </summary>
    public Mock<IWordDictionaryService> mockWordDictionary = new Mock<IWordDictionaryService>();

    /// <summary>
    /// Puzzles the services API generate word ladder.
    /// </summary>
    [Fact(DisplayName = "Generate Word Ladder")]
    public async void Puzzle_ServicesApi_GenerateWordLadder()
    {
        // Arrange
        var faker = new Faker("en");
        var request = new WordLadderViewModel
        {
            StartWord = new WordViewModel
            {
                Value = faker.PickRandom(fixture.dictionary),
                Type = faker.PickRandom<WordType>()
            },
            EndWord = new WordViewModel
            {
                Value = faker.PickRandom(fixture.dictionary),
                Type = faker.PickRandom<WordType>()
            },
            AnswerFileName = new AnswerViewModel
            {
                Extension = faker.System.CommonFileType(),
                FileName = faker.System.CommonFileName(),
                Path = faker.System.DirectoryPath()
            },
            Dictionary = new WordDictionaryViewModel
            {
                Default = faker.Random.Word(),
                File = faker.Random.Bytes(100)
            },
        };

        var respose = new WordLadderViewModel
        {
            StartWord = new WordViewModel
            {
                Value = faker.PickRandom(fixture.dictionary),
                Type = faker.PickRandom<WordType>()
            },
            EndWord = new WordViewModel
            {
                Value = faker.PickRandom(fixture.dictionary),
                Type = faker.PickRandom<WordType>()
            },
            AnswerFileName = new AnswerViewModel
            {
                Extension = faker.System.CommonFileType(),
                FileName = faker.System.CommonFileName(),
                Path = faker.System.DirectoryPath()
            },
            Dictionary = new WordDictionaryViewModel
            {
                Default = faker.Random.Word(),
                File = faker.Random.Bytes(100)
            },
        };

        //Act
        mockWordLadder.Setup(p => p.Generate(request)).ReturnsAsync(respose);
        WordLadderController wlController = new WordLadderController(mockWordLadder.Object);
        var result = await wlController.Generate(request);

        //Assert
        result.Should().NotBeNull();

    }

    /// <summary>
    /// Puzzles the services API get word dictionary.
    /// </summary>
    [Fact(DisplayName = "Get Word Dictionary")]
    public async void Puzzle_ServicesApi_GetWordDictionary()
    {
        // Arrange
        var faker = new Faker<WordDictionaryViewModel>()
            .RuleFor(u => u.Default, f => f.Random.Word())
            .RuleFor(o => o.File, f => f.Random.Bytes(100));

        //Act
        mockWordDictionary.Setup(p => p.GetDefault()).ReturnsAsync(faker);
        WordDictionaryController wdController = new WordDictionaryController(mockWordDictionary.Object);
        var result = await wdController.GetDefault();

        //Assert
        result.Should().NotBeNull();
    }
}

