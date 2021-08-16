using Puzzle.Domain.Enumerations;
using System.Collections.Generic;

namespace Puzzle.Application.ViewModels
{
    public class WordViewModel : EntityViewModel
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public WordType Type { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the allowed words.
        /// </summary>
        /// <value>
        /// The allowed words.
        /// </value>
        public List<string> AllowedWords { get; set; }
    }
}