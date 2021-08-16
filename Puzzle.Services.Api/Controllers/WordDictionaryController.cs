using Microsoft.AspNetCore.Mvc;
using Puzzle.Application.Interfaces;
using Puzzle.Application.ViewModels;
using System.Threading.Tasks;

namespace Puzzle.Services.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordDictionaryController
    {
        /// <summary>
        /// The word dictionary asynchronous
        /// </summary>
        private readonly IWordDictionaryService _wordDictionaryAsync;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordDictionaryService"/> class.
        /// </summary>
        /// <param name="wordDictionaryAsync">The WordDictionary service asynchronous.</param>
        public WordDictionaryController(IWordDictionaryService wordDictionaryAsync)
        {
            this._wordDictionaryAsync = wordDictionaryAsync;
        }

        /// <summary>
        /// Gets the default.
        /// </summary>
        /// <returns>Word Dictionary</returns>
        [HttpGet]
        public async Task<WordDictionaryViewModel> GetDefault()
        {
            return await _wordDictionaryAsync.GetDefault();
        }
    }
}