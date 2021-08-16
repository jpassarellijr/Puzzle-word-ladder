using Puzzle.Application.Validation;
using Puzzle.Application.ViewModels;
using Puzzle.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.IO;

namespace Puzzle.ConsoleApp.Helper
{
    /// <summary>
    ///   Responsible for managing console app calls
    /// </summary>
    public class ConsoleCommand
    {
        /// <summary>
        /// Sets the word dictionary.
        /// </summary>
        /// <returns></returns>
        public static WordDictionaryViewModel SetWordDictionary()
        {
            string selectionDefault;
            WordDictionaryViewModel dic;

            while (true)
            {
                Console.WriteLine("Would you like to use the default word dictionary (words-english.txt)? [Y]es or [N]o");
                selectionDefault = Console.ReadLine().ToUpper();
                dic = new WordDictionaryViewModel
                {
                    Default = selectionDefault
                };

                var result = dic.Validate(dic, new DictionaryValidation());

                if (result)
                {
                    break;
                }

                foreach (var failure in dic.ValidationResult.Errors)
                {
                    Console.WriteLine(failure.ErrorMessage);
                }
            }

            if (selectionDefault == "N")
            {
                while (true)
                {
                    Console.WriteLine(@"Please enter the full path of your .TXT file with your word dictionary. (Example: c:\worddic.txt)");
                    var fullPath = Console.ReadLine().ToUpper();

                    if (File.Exists(fullPath))
                    {
                        dic.File = TextFile.NewFile(fullPath);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(@"Please provide a valid path.");
                    }
                }
            }
            else
            {
                dic.File = TextFile.GetFile();
            }

            return dic;
        }

        /// <summary>
        /// Sets the word.
        /// </summary>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="type">The type.</param>
        /// <param name="wordList">The word list.</param>
        /// <returns></returns>
        public static WordViewModel SetWord(string argumentName, WordType type, List<string> wordList)
        {
            WordViewModel word;

            while (true)
            {
                Console.WriteLine($"Please, enter the {argumentName}: ");
                var argument = Console.ReadLine().ToUpper();

                word = new WordViewModel
                {
                    Value = argument,
                    Type = type,
                    AllowedWords = wordList
                };

                var result = new WordViewModel().Validate(word, new WordValidation());

                if (result)
                {
                    break;
                }

                foreach (var failure in word.ValidationResult.Errors)
                {
                    Console.WriteLine(failure.ErrorMessage);
                }
            }

            return word;
        }

        /// <summary>
        /// Sets the answer.
        /// </summary>
        /// <param name="argumentName">Name of the argument.</param>
        /// <returns></returns>
        public static AnswerViewModel SetAnswer(string argumentName)
        {
            AnswerViewModel answer;

            while (true)
            {
                Console.WriteLine($"Please, enter the {argumentName}: ");
                var argument = Console.ReadLine().ToUpper();
                answer = new AnswerViewModel
                {
                    FileName = argument,
                    Extension = ".txt"
                };

                var result = new AnswerViewModel().Validate(answer, new AnswerValidation());

                //Validate if the dictionary contains this word
                if (result)
                {
                    break;
                }

                foreach (var failure in answer.ValidationResult.Errors)
                {
                    Console.WriteLine(failure.ErrorMessage);
                }
            }

            return answer;
        }
    }
}