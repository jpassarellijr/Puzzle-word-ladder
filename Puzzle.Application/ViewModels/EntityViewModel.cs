using FluentValidation;
using FluentValidation.Results;

namespace Puzzle.Application.ViewModels
{
    public abstract class EntityViewModel
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="EntityViewModel"/> is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if valid; otherwise, <c>false</c>.
        /// </value>
        public bool Valid { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="EntityViewModel"/> is invalid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if invalid; otherwise, <c>false</c>.
        /// </value>
        public bool Invalid => !Valid;

        /// <summary>
        /// Gets the validation result.
        /// </summary>
        /// <value>
        /// The validation result.
        /// </value>
        public ValidationResult ValidationResult { get; private set; }

        /// <summary>
        /// Validates the specified model.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="model">The model.</param>
        /// <param name="validator">The validator.</param>
        /// <returns></returns>
        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}