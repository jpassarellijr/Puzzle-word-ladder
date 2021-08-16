using Puzzle.Domain.Models;
using Puzzle.Infra.Data.Interfaces;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Puzzle.Infra.Data.Services
{
    public class WordDictionaryServiceApi : IWordDictionaryServiceApi
    {
        /// <summary>
        /// Gets the default.
        /// </summary>
        /// <returns></returns>
        public async Task<WordDictionary> GetDefault()
        {
            var obj = new WordDictionary();
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"words-english.txt");
            obj.File = await File.ReadAllBytesAsync(path);

            return obj;
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