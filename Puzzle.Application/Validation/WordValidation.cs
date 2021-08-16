using FluentValidation;
using Puzzle.Application.ViewModels;

namespace Puzzle.Application.Validation
{
    public class WordValidation : AbstractValidator<WordViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WordValidation"/> class.
        /// </summary>
        public WordValidation()
        {
            RuleFor(c => c.Value)
                .NotEmpty().WithMessage("Please ensure you have entered the word.")
                .Length(4).WithMessage("The word must be exactly 4 characters long.");

            RuleFor(c => c)
                .Must(c => c.AllowedWords.Contains(c.Value)).WithMessage($"This word is not contained in the dictionary, please insert a new word.");
        }
    }
}