using Newtonsoft.Json;
using Puzzle.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;

namespace Puzzle.ConsoleApp.Helper
{
    /// <summary>
    /// Responsible for managing calls referring to the text file
    /// </summary>
    public class TextFile
    {
        /// <summary>
        /// The URI services API
        /// </summary>
        internal const string uriServicesApi = "https://localhost:44376/";

        /// <summary>
        /// Creates new file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>the dictionary file (byte array)</returns>
        public static byte[] NewFile(string path)
        {
            byte[] file = File.ReadAllBytes(path);

            return file;
        }

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <returns>the dictionary file (byte array)</returns>
        public static byte[] GetFile()
        {
            WordDictionaryViewModel wordDic = new();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriServicesApi);

                var responseTask = client.GetAsync("WordDictionary");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var responseContent = result.Content.ReadAsStringAsync();
                    wordDic = JsonConvert.DeserializeObject<WordDictionaryViewModel>(responseContent.Result);
                }
            }

            return wordDic.File;
        }

        /// <summary>
        /// Generates the word ladder.
        /// </summary>
        /// <param name="wordLadder">The word ladder.</param>
        /// <returns>the word ladder</returns>
        public static WordLadderViewModel GenerateWordLadder(WordLadderViewModel wordLadder)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriServicesApi);

                var postTask = client.PostAsJsonAsync("WordLadder", wordLadder);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var responseContent = result.Content.ReadAsStringAsync();
                    wordLadder = JsonConvert.DeserializeObject<WordLadderViewModel>(responseContent.Result);
                }
            }

            return wordLadder;
        }

        /// <summary>
        /// Stores the data in list.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>list of words</returns>
        public static List<string> StoreDataInList(byte[] file)
        {
            var words = new List<string>();
            string line;
            if (file != null)
            {
                using (MemoryStream memoryStream = new(file))
                {
                    using (TextReader textReader = new StreamReader(memoryStream))
                    {
                        while ((line = textReader.ReadLine()) != null)
                            words.Add(line.ToUpper());
                    }
                }
            }

            return words;
        }
    }
}