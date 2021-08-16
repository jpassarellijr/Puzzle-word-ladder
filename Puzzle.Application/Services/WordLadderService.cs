using AutoMapper;
using Microsoft.Extensions.Configuration;
using Puzzle.Application.ViewModels;
using Puzzle.Domain.Interfaces;
using Puzzle.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Puzzle.Application.Services
{
    public class WordLadderService : Interfaces.IWordLadderService
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The word ladder service
        /// </summary>
        private readonly IWordLadderService _wordLadderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordLadderService{Tv, Te}" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="mediator">The mediator.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="wordLadderService">The word ladder service.</param>
        public WordLadderService(IConfiguration configuration, IMapper mapper, IWordLadderService wordLadderService)
        {
            Configuration = configuration;
            _mapper = mapper;
            _wordLadderService = wordLadderService;
        }

        /// <summary>
        /// Generates the specified word ladder
        /// </summary>
        /// <param name="req">The word ladder requirements</param>
        /// <returns>
        /// answer file with word ladder
        /// </returns>
        public async Task<WordLadderViewModel> Generate(WordLadderViewModel req)
        {
            return _mapper.Map<WordLadderViewModel>(await _wordLadderService.GenerateWordLadder(_mapper.Map<WordLadder>(req)));
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}