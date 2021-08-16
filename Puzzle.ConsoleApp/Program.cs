using Puzzle.Application.ViewModels;
using Puzzle.ConsoleApp.Helper;
using Puzzle.Domain.Enumerations;
using System;

namespace Puzzle.ConsoleApp
{
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        private static void Main()
        {
            var wordLadder = new WordLadderViewModel
            {
                Dictionary = ConsoleCommand.SetWordDictionary()
            };
            var wordList = TextFile.StoreDataInList(wordLadder.Dictionary.File);
            wordLadder.StartWord = ConsoleCommand.SetWord("Start Word (should be 4 characters long)", WordType.Start, wordList);
            wordLadder.EndWord = ConsoleCommand.SetWord("End Word (should be 4 characters long)", WordType.End, wordList);
            wordLadder.AnswerFileName = ConsoleCommand.SetAnswer("Answer file name (only the name, without the extension)");

            wordLadder = TextFile.GenerateWordLadder(wordLadder);
            if (wordLadder.AnswerFileName.Path != null)
            {
                Console.WriteLine("File with the result stored in: " + wordLadder.AnswerFileName.Path);
            }
            else
            {
                Console.WriteLine("It was not possible to create a ladder word for the chosen words with the selected dictionary.");
            }
        }
    }
}