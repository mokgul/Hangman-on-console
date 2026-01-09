using System.IO;
using System.Text;
using System.Linq;
using System;

namespace Hangman_on_console
{
    public class Generate_word
    {
        // Words in file
        public static string[] WordsInFile { get; set; }

        public static string Generate()
        {
            string randomWord = "";
            string filePath = Path.Combine(Path.GetDirectoryName
                (System.Reflection.Assembly.GetExecutingAssembly().Location), "Words.txt");
            using (TextReader tr = new StreamReader(filePath, Encoding.ASCII))
            {
                Random r = new Random();
                var allWords = tr.ReadToEnd().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                WordsInFile = allWords;
                randomWord = allWords[r.Next(0, allWords.Length - 1)].ToLower();
            }
            return randomWord;
        }
    }
}
