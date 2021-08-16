using Bogus;
using FluentAssertions;
using Moq;
using Puzzle.Application.Services;
using Puzzle.Application.Validation;
using Puzzle.Application.ViewModels;
using Puzzle.Domain.Enumerations;
using Puzzle.Domain.Interfaces;
using Puzzle.Domain.Models;
using Puzzle.Infra.Data.Interfaces;
using System.Collections.Generic;
using Xunit;

[Trait("Puzzle", "Application")]
public class ApplicationTests : IClassFixture<PuzzleFixture>
{
    /// <summary>
    /// The fixture
    /// </summary>
    PuzzleFixture fixture;

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainTests"/> class.
    /// </summary>
    /// <param name="fixture">The fixture.</param>
    public ApplicationTests(PuzzleFixture fixture)
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
    public Mock<IWordDictionaryServiceApi> mockWordDictionary = new Mock<IWordDictionaryServiceApi>();

    /// <summary>
    /// Puzzles  generate word ladder.
    /// </summary>
    [Fact(DisplayName = "Generate Word Ladder")]
    public void Puzzle_Application_GenerateWordLadder()
    {
        // Arrange
        var faker = new Faker("en");
        var requestApp = new WordLadderViewModel
        {
            StartWord = new WordViewModel
            {
                Value = faker.PickRandom(fixture.dictionary),
                AllowedWords = fixture.dictionary,
                Type = faker.PickRandom<WordType>()
            },
            EndWord = new WordViewModel
            {
                Value = faker.PickRandom(fixture.dictionary),
                AllowedWords = fixture.dictionary,
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

        var respose = new WordLadder
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
        mockWordLadder.Setup(p => p.GenerateWordLadder(request)).ReturnsAsync(respose);
        WordLadderService wlApp = new WordLadderService(null, null, mockWordLadder.Object);
        var result = wlApp.Generate(requestApp);

        //Assert
        result.Should().NotBeNull();

    }

    /// <summary>
    /// Puzzles get word dictionary.
    /// </summary>
    [Fact(DisplayName = "Get Word Dictionary")]
    public void Puzzle_ServicesApi_GetWordDictionary()
    {
        // Arrange
        var faker = new Faker<WordDictionary>()
            .RuleFor(u => u.Default, f => f.Random.Word())
            .RuleFor(o => o.File, f => f.Random.Bytes(100));

        //Act
        mockWordDictionary.Setup(p => p.GetDefault()).ReturnsAsync(faker);
        WordDictionaryService wdApp = new WordDictionaryService(null, null, null);
        var result = wdApp.GetDefault();

        //Assert
        result.Should().NotBeNull();
    }

    /// <summary>
    /// Puzzles the application validate answer.
    /// </summary>
    [Fact(DisplayName = "Validate Answer")]
    public void Puzzle_Application_ValidateAnswer()
    {
        // Arrange
        var faker = new Faker("en");

        var answerFileName = new AnswerViewModel
        {
            Extension = faker.System.FileExt(),
            FileName = faker.Random.Word(),
            Path = faker.System.DirectoryPath()
        };

        //Act
        var result = new AnswerViewModel().Validate(answerFileName, new AnswerValidation());

        //Assert
        result.Should().BeTrue();

    }

    /// <summary>
    /// Puzzles the application validate word.
    /// </summary>
    [Fact(DisplayName = "Validate Word")]
    public void Puzzle_Application_ValidateWord()
    {
        // Arrange
        var faker = new Faker("en");
        fixture.dictionary.RemoveAll(word => word.Length != 4);

        var word = new WordViewModel
        {
            Value = faker.PickRandom(fixture.dictionary),
            AllowedWords = fixture.dictionary,
            Type = faker.PickRandom<WordType>()
        };

        //Act
        var result = new WordViewModel().Validate(word, new WordValidation());

        //Assert
        result.Should().BeTrue();

    }

    /// <summary>
    /// Puzzles the application validate word dictionary successfully.
    /// </summary>
    [Fact(DisplayName = "Validate WordDictionary successfully")]
    public void Puzzle_Application_ValidateWordDictionarySuccessfully()
    {
        // Arrange
        var faker = new Faker("en");
        var correctResponse = new List<string>() { "Y", "N" };

        var dictionary = new WordDictionaryViewModel
        {
            Default = faker.PickRandom(correctResponse),
            File = faker.Random.Bytes(100)
        };


        //Act
        var result = new WordDictionaryViewModel().Validate(dictionary, new DictionaryValidation());

        //Assert
        result.Should().BeTrue();

    }

    /// <summary>
    /// Puzzles the application validate word dictionary error.
    /// </summary>
    [Fact(DisplayName = "Validate WordDictionary with error")]
    public void Puzzle_Application_ValidateWordDictionaryError()
    {
        // Arrange
        var faker = new Faker("en");

        var dictionary = new WordDictionaryViewModel
        {
            Default = faker.Random.Word(),
            File = faker.Random.Bytes(100)
        };


        //Act
        var result = new WordDictionaryViewModel().Validate(dictionary, new DictionaryValidation());

        //Assert
        result.Should().BeFalse();

    }
}

