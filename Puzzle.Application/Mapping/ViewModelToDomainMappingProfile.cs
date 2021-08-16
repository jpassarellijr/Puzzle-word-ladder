using AutoMapper;
using Puzzle.Application.ViewModels;
using Puzzle.Domain.Models;

namespace Puzzle.Application.Mapping
{
    /// <summary>
    /// Mapping file ViewModel to Domain
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ViewModelToDomainMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelToDomainMappingProfile"/> class.
        /// </summary>
        public ViewModelToDomainMappingProfile()
        {
            this.CreateMap<WordDictionaryViewModel, WordDictionary>();
            this.CreateMap<WordLadderViewModel, WordLadder>();
            this.CreateMap<AnswerViewModel, Answer>();
            this.CreateMap<WordViewModel, Word>();
        }
    }
}