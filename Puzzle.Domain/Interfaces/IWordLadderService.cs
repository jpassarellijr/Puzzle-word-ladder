using Puzzle.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Puzzle.Domain.Interfaces
{
    public interface IWordLadderService : IDisposable
    {
        /// <summary>
        /// Generates the word ladder.
        /// </summary>
        /// <param name="wordLadder">The word ladder.</param>
        /// <returns></returns>
        Task<WordLadder> GenerateWordLadder(WordLadder wordLadder);
    }
}