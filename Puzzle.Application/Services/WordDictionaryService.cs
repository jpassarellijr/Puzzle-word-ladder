using AutoMapper;
using Microsoft.Extensions.Configuration;
using Puzzle.Application.Interfaces;
using Puzzle.Application.ViewModels;
using Puzzle.Infra.Data.Interfaces;
using System;
using System.Threading.Tasks;

namespace Puzzle.Application.Services
{
    public class WordDictionaryService : IWordDictionaryService
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration _configuration { get; set; }

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The word dictionary service API
        /// </summary>
        private readonly IWordDictionaryServiceApi _wordDictionaryServiceApi;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordDictionaryService{Tv, Te}" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="mediator">The mediator.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="wordDictionaryServiceApi">The word dictionary service API.</param>
        public WordDictionaryService(IConfiguration configuration, IMapper mapper, IWordDictionaryServiceApi wordDictionaryServiceApi)
        {
            _configuration = configuration;
            _mapper = mapper;
            _wordDictionaryServiceApi = wordDictionaryServiceApi;
        }

        /// <summary>
        /// Gets the default.
        /// </summary>
        /// <returns>the dictionary</returns>
        public async Task<WordDictionaryViewModel> GetDefault()
        {
            return _mapper.Map<WordDictionaryViewModel>(await _wordDictionaryServiceApi.GetDefault());
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