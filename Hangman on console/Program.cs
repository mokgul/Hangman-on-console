using System;
using System.Linq;
using System.Text;

namespace Hangman_on_console
{
    class Program
    {
        private static void Main(string[] args)
        {
            int choice = -1;
            while (choice != 0)
            {
                DisplayConsoleMenu();
                choice = ReadUserInputInteger();

                switch (choice)
                {
                    case 0:
                        Console.Clear();
                        Highscores.UpdateFile();
                        Console.WriteLine("Thank you for playing !");
                        return;
                    case 1:
                        Console.Clear();
                        NewGame(); 
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Hangman Game rules:");
                        Console.WriteLine();
                        Console.WriteLine("1.First you are asked to enter a name, needed for the highscore table.");
                        Console.WriteLine();
                        Console.WriteLine("2.A word is generated,your goal is to guess the word.");
                        Console.WriteLine();
                        Console.WriteLine("3.A valid input is considered a single character or a word equal to the full length of the word.");
                        Console.WriteLine();
                        Console.WriteLine("-- ex. \"game\". A valid input is either a single character or word with 4 letters");
                        Console.WriteLine("-- Everything else is considered as invalid input !!!");
                        Console.WriteLine();
                        Console.WriteLine("4.For each word there are 9 attempts available.");
                        Console.WriteLine();
                        Console.WriteLine("5.Good luck !");
                        break;
                    case 3:
                        Console.Clear();
                        PlayerGuess.GetListGuessedWords();
                        break;
                    case 4:
                        Console.Clear();
                        PlayerGuess.GuessedWords.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine();
                        Console.WriteLine($"The list has been cleared !");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 5:
                        Console.Clear();
                        Generate_word.Generate();
                        for (int i = 0; i < Generate_word.WordsInFile.Length; i++)
                        {
                            Console.WriteLine($"{i}. {Generate_word.WordsInFile[i]}");
                        }
                        break;
                    case 6:
                        Console.Clear();
                        Highscores.UpdateFile();
                        Highscores.LoadFile();
                        Console.WriteLine(string.Join(Environment.NewLine,
                            Highscores.Entries.OrderByDescending(x => x.Value)));
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Game made by @Mokgul");
                        Console.WriteLine();
                        Console.WriteLine("Date: 8-8-2022");
                        Console.WriteLine();
                        Console.WriteLine("This game was made as a side project during my studies at Software University.");
                        Console.WriteLine();
                        Console.WriteLine("Time to complete: Between 8 and 10 hours");
                        Console.WriteLine();
                        Console.WriteLine("Credits to: ");
                        Console.WriteLine();
                        Console.WriteLine("Kaiser DMC - menu layout, game rules and some other ideas");
                        Console.WriteLine();
                        Console.WriteLine("Thank you for playing !");
                        break;
                }
            }
        }

        private static void NewGame()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Enter player name: ");
            Console.ForegroundColor = ConsoleColor.White;
            
            string user = Console.ReadLine();
            PlayerGuess.Highscore.Add(user, 0);
            Console.WriteLine();
            //declarations
            #region
            //generate a word
            generate:
            string currentWord = Generate_word.Generate(); //generated word
            StringBuilder word = new StringBuilder(currentWord);
            // string with the same value, used for comparassion and getting index of the guessed char
            
            char[] hiddenWord = new char[currentWord.Length];
            for (int i = 0; i < currentWord.Length; i++) hiddenWord[i] = '*';
            //char array, using it to save the guessed chars
            #endregion
            //CW just for the tests while making the game
            Console.WriteLine(currentWord);

            PlayerGuess.PlayerGuessing(currentWord,word,hiddenWord,user);
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("What would you like to do next: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("    Enter 1: To generate a new word");
            Console.WriteLine("    Enter 0: To go back to the menu");
            string input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "1": goto generate;
                case "0":
                    Console.Clear(); break;
            }
        }

        private static void DisplayConsoleMenu()
        {
            //Menu formatting

            Console.WriteLine();
            Console.WriteLine(" +++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("\n                        MENU                        ");
            Console.WriteLine("\n +++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine(" Start a new game                               :1 ");
            Console.WriteLine(" Game Rules                                     :2 ");
            Console.WriteLine(" List of guessed words                          :3 ");
            Console.WriteLine(" Clear list of guessed words                    :4 ");
            Console.WriteLine(" Get full list of available word                :5 ");
            Console.WriteLine(" Highscores                                     :6 ");
            Console.WriteLine(" Credits                                        :7 ");
            Console.WriteLine(" Exit the program                               :0 ");
            Console.WriteLine(" +++++++++++++++++++++++++++++++++++++++++++++++++++\n");
            Console.Write(" Which program would you like to access?: ");
        }
        public static int ReadUserInputInteger()
        {
            int input;

            if (int.TryParse(Console.ReadLine(), out input))
                return input;
            else
                Console.WriteLine($"Wrong input. The value is not a whole number. Please try again: ");

            return ReadUserInputInteger();
        }
    }
}
