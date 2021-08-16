using FluentValidation;
using Puzzle.Application.ViewModels;

namespace Puzzle.Application.Validation
{
    public class DictionaryValidation : AbstractValidator<WordDictionaryViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryValidation"/> class.
        /// </summary>
        public DictionaryValidation()
        {
            RuleFor(m => m.Default)
                .In("Y", "N");
        }
    }
}