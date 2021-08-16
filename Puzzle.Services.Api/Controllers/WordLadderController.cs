using Microsoft.AspNetCore.Mvc;
using Puzzle.Application.Interfaces;
using Puzzle.Application.ViewModels;
using System.Net;
using System.Threading.Tasks;

namespace Puzzle.Services.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordLadderController
    {
        /// <summary>
        /// The word ladder asynchronous
        /// </summary>
        private readonly IWordLadderService _wordLadderAsync;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordLadderController"/> class.
        /// </summary>
        /// <param name="wordLadderAsync">The WordLadder service asynchronous.</param>
        public WordLadderController(IWordLadderService wordLadderAsync)
        {
            this._wordLadderAsync = wordLadderAsync;
        }

        /// <summary>
        /// Generates the specified word ladder.
        /// </summary>
        /// <param name="obj">The word ladder information.</param>
        /// <returns>the answer file</returns>
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<WordLadderViewModel> Generate([FromBody] WordLadderViewModel obj)
        {
            return await this._wordLadderAsync.Generate(obj);
        }
    }
}