namespace Puzzle.Domain.Models
{
    public class WordLadder
    {
        /// <summary>
        /// Gets or sets the dictionary.
        /// </summary>
        /// <value>
        /// The dictionary.
        /// </value>
        public WordDictionary Dictionary { get; set; }

        /// <summary>
        /// Gets or sets the start word.
        /// </summary>
        /// <value>
        /// The start word.
        /// </value>
        public Word StartWord { get; set; }

        /// <summary>
        /// Gets or sets the end word.
        /// </summary>
        /// <value>
        /// The end word.
        /// </value>
        public Word EndWord { get; set; }

        /// <summary>
        /// Gets or sets the name of the answer file.
        /// </summary>
        /// <value>
        /// The name of the answer file.
        /// </value>
        public Answer AnswerFileName { get; set; }
    }
}