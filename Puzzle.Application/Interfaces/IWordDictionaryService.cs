using Puzzle.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace Puzzle.Application.Interfaces
{
    public interface IWordDictionaryService : IDisposable
    {
        /// <summary>
        /// Gets the default.
        /// </summary>
        /// <returns>the dictionary</returns>
        Task<WordDictionaryViewModel> GetDefault();
    }
}