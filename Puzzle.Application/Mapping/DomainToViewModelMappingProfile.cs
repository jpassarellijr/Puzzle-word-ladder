using AutoMapper;
using Puzzle.Application.ViewModels;
using Puzzle.Domain.Models;

namespace Puzzle.Application.Mapping
{
    /// <summary>
    /// Mapping file Domain to ViewModel
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainToViewModelMappingProfile"/> class.
        /// </summary>
        public DomainToViewModelMappingProfile()
        {
            this.CreateMap<WordDictionary, WordDictionaryViewModel>();
            this.CreateMap<WordLadder, WordLadderViewModel>();
            this.CreateMap<Answer, AnswerViewModel>();
            this.CreateMap<Word, WordViewModel>();
        }
    }
}