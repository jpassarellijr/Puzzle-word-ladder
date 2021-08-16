namespace Puzzle.Application.ViewModels
{
    public class WordLadderViewModel
    {
        /// <summary>
        /// Gets or sets the dictionary.
        /// </summary>
        /// <value>
        /// The dictionary.
        /// </value>
        public WordDictionaryViewModel Dictionary { get; set; }

        /// <summary>
        /// Gets or sets the start word.
        /// </summary>
        /// <value>
        /// The start word.
        /// </value>
        public WordViewModel StartWord { get; set; }

        /// <summary>
        /// Gets or sets the end word.
        /// </summary>
        /// <value>
        /// The end word.
        /// </value>
        public WordViewModel EndWord { get; set; }

        /// <summary>
        /// Gets or sets the name of the answer file.
        /// </summary>
        /// <value>
        /// The name of the answer file.
        /// </value>
        public AnswerViewModel AnswerFileName { get; set; }
    }
}