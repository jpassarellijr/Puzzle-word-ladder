using FluentValidation;
using Puzzle.Application.ViewModels;

namespace Puzzle.Application.Validation
{
    public class AnswerValidation : AbstractValidator<AnswerViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnswerValidation"/> class.
        /// </summary>
        public AnswerValidation()
        {
            RuleFor(c => c.FileName)
                .NotEmpty().WithMessage("Please ensure you have entered the filename.")
                .MaximumLength(10).WithMessage("The name cannot be longer than 10 characters.");
        }
    }
}