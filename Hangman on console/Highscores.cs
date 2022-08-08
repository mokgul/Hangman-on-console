using System;
using System.Collections.Generic;
using System.IO;


namespace Hangman_on_console
{
    public class Highscores
    {
        public Highscores()
        {
            Entries = new Dictionary<string, int>();
        }
        public static Dictionary<string,int> Entries = new Dictionary<string,int>();
        public static void LoadFile()
        {
            using(StreamReader sr = File.OpenText("Highscore.txt"))
            {
                var allEntries = sr.ReadToEnd().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < allEntries.Length; i++)
                {
                    string[] item = allEntries[i].Split(new char[] { '[', ',', ']' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = item[0];
                    int score = int.Parse(item[1]);
                    if (!Entries.ContainsKey(name))
                    {
                        Entries.Add(name, score);
                    }
                }
            }
        }
        public static void UpdateFile()
        {
            
            using(StreamWriter sw = File.AppendText("Highscore.txt"))
            {
                if(PlayerGuess.Highscore != null)
                {
                    foreach (var item in PlayerGuess.Highscore)
                    {
                        sw.WriteLine(item);
                    }
                }
            };
        }
    }
}