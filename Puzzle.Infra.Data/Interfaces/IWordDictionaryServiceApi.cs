using Puzzle.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Puzzle.Infra.Data.Interfaces
{
    public interface IWordDictionaryServiceApi : IDisposable
    {
        /// <summary>
        /// Gets the default.
        /// </summary>
        /// <returns></returns>
        Task<WordDictionary> GetDefault();
    }
}