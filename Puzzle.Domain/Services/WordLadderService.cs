using Puzzle.Domain.Interfaces;
using Puzzle.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle.Domain.Services
{
    public class WordLadderService : IWordLadderService
    {
        /// <summary>
        /// Any letter
        /// </summary>
        internal static char anyLetter = '?';

        /// <summary>
        /// Generates the word ladder.
        /// </summary>
        /// <param name="wordLadder">The word ladder.</param>
        /// <returns></returns>
        public async Task<WordLadder> GenerateWordLadder(WordLadder wordLadder)
        {
            var synthesizedDictionary = SynthesizeDictionary(wordLadder);
            var returnLadder = CreateLadder(wordLadder, synthesizedDictionary)[0].ToList();
            wordLadder.AnswerFileName.Path = await CreateAnswerFile(wordLadder, returnLadder);

            return wordLadder;
        }

        /// <summary>
        /// Creates the answer file.
        /// </summary>
        /// <param name="wordLadder">The word ladder.</param>
        /// <param name="returnLadder">The return ladder.</param>
        /// <returns></returns>
        internal static async Task<string> CreateAnswerFile(WordLadder wordLadder, List<string> returnLadder)
        {
            string AnswerFullName = wordLadder.AnswerFileName.FileName + wordLadder.AnswerFileName.Extension;

            TextWriter tw = new StreamWriter(AnswerFullName);

            foreach (String s in returnLadder)
                await tw.WriteLineAsync(s);

            tw.Close();

            return Path.Combine(Directory.GetCurrentDirectory(), AnswerFullName);
        }

        /// <summary>
        /// Synthesizes the dictionary.
        /// </summary>
        /// <param name="wordLadder">The word ladder.</param>
        /// <returns></returns>
        private static List<string> SynthesizeDictionary(WordLadder wordLadder)
        {
            wordLadder.StartWord.AllowedWords.RemoveAll(word => word.Length != 4);
            wordLadder.StartWord.AllowedWords = new HashSet<string>(wordLadder.StartWord.AllowedWords).ToList();

            char[] arrayStart = wordLadder.StartWord.Value.ToCharArray();
            char[] arrayEnd = wordLadder.EndWord.Value.ToCharArray();
            var array = new char[arrayStart.Length + arrayEnd.Length];
            arrayEnd.CopyTo(array, 0);
            arrayStart.CopyTo(array, arrayEnd.Length);
            var charsStartEnd = new HashSet<char>(array).ToArray();
            wordLadder.StartWord.AllowedWords.RemoveAll(word => word.IndexOfAny(charsStartEnd) != 0);

            return wordLadder.StartWord.AllowedWords;
        }

        /// <summary>
        /// Creates the ladder.
        /// </summary>
        /// <param name="wordLadder">The word ladder.</param>
        /// <param name="synthesizedDictionary">The synthesized dictionary.</param>
        /// <returns>all possible word ladders</returns>
        private static IList<IList<string>> CreateLadder(WordLadder wordLadder, List<string> synthesizedDictionary)
        {
            //init
            Queue<string> queue = new();
            Dictionary<string, IList<IList<string>>> ladderPuzzle = new();
            HashSet<string> wordVisited = new();
            Dictionary<string, HashSet<string>> graph = new();

            //populate
            ladderPuzzle[wordLadder.StartWord.Value] = new List<IList<string>>() { new List<string>() { wordLadder.StartWord.Value } };
            queue.Enqueue(wordLadder.StartWord.Value);            
            CreateMapGraph(synthesizedDictionary, graph);

            //BFS
            while (queue.Count > 0)
            {
                var lastWord = queue.Dequeue();
                if (lastWord.Equals(wordLadder.EndWord.Value))
                {
                    return ladderPuzzle[wordLadder.EndWord.Value];
                }
                else
                {
                    if (wordVisited.Contains(lastWord))
                        continue;
                    else
                        wordVisited.Add(lastWord);

                    for (int i = 0; i < lastWord.Length; i++)
                    {
                        var rung = ((new StringBuilder(lastWord)).Remove(i,1).Insert(i, anyLetter)).ToString();

                        if (graph.ContainsKey(rung))
                        {
                            foreach (var word in graph[rung])
                            {
                                if (!wordVisited.Contains(word))
                                {
                                    foreach (var path in ladderPuzzle[lastWord])
                                    {
                                        var newLadderPuzzle = new List<string>(path){word};

                                        if (!ladderPuzzle.ContainsKey(word))
                                            ladderPuzzle[word] = new List<IList<string>>() {newLadderPuzzle};
                                        else if (ladderPuzzle[word][0].Count >= newLadderPuzzle.Count)
                                            ladderPuzzle[word].Add(newLadderPuzzle);
                                    }
                                    queue.Enqueue(word);
                                }
                            }
                        }
                    }
                }
            }

            return new List<IList<string>>();
        }

        /// <summary>
        /// Creates the map graph.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="graph">The graph.</param>
        private static void CreateMapGraph(List<string> dictionary, Dictionary<string, HashSet<string>> graph)
        {
            foreach(var w in dictionary)
            {
                for (int c = 0; c < w.Length; c++)
                {
                    var possibility = ((new StringBuilder(w)).Remove(c, 1).Insert(c, anyLetter)).ToString();

                    if (graph.ContainsKey(possibility))
                    {
                        graph[possibility].Add(w);
                    }
                    else
                    {
                        graph[possibility] = new HashSet<string>{w};
                    }
                }
            }
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