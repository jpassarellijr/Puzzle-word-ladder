namespace Puzzle.Application.ViewModels
{
    public class WordDictionaryViewModel : EntityViewModel
    {
        /// <summary>
        /// Gets or sets the default.
        /// </summary>
        /// <value>
        /// The default.
        /// </value>
        public string Default { get; set; }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        /// <value>
        /// The file.
        /// </value>
        public byte[] File { get; set; }
    }
}