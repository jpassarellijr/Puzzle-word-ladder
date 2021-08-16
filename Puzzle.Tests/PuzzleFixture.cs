using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public class PuzzleFixture : IDisposable
{
    /// <summary>
    /// The dictionary
    /// </summary>
    public List<string> dictionary = new();

    /// <summary>
    /// The dic file
    /// </summary>
    public byte[] dicFile;

    /// <summary>
    /// The path
    /// </summary>
    public string path;

    /// <summary>
    /// Initializes a new instance of the <see cref="PuzzleFixture"/> class.
    /// </summary>
    public PuzzleFixture()
    {
        path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"words-english.txt");
        dicFile = File.ReadAllBytes(path);

        string readLine;
        using (MemoryStream memoryStream = new MemoryStream(dicFile))
        {
            using (TextReader textReader = new StreamReader(memoryStream))
            {
                while ((readLine = textReader.ReadLine()) != null)
                    //Input string converted to uppercase to allow for case sensitive search functions
                    dictionary.Add(readLine.ToUpper());
            }
        }
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        dictionary = new List<string>();
        dicFile = null;
    }
}