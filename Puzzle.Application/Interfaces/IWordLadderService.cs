using Puzzle.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace Puzzle.Application.Interfaces
{
    public interface IWordLadderService : IDisposable
    {
        /// <summary>
        /// Generates the specified req.
        /// </summary>
        /// <param name="req">The req.</param>
        /// <returns>word ladder answer</returns>
        Task<WordLadderViewModel> Generate(WordLadderViewModel req);
    }
}