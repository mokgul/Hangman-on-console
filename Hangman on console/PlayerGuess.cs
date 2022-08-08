using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman_on_console
{
    
    public class PlayerGuess
    {
        public PlayerGuess()
        {
            GuessedWords = new List<string>();
        }
        public static List<string> GuessedWords = new List<string>();

        public static Dictionary<string,int> Highscore = new Dictionary<string,int>();
        public static void PlayerGuessing(string currentWord,StringBuilder word,char[] hiddenWord,string user)
        {
            bool wordGuessed = false;
            int loseCounter = 0;
            List<char> wrongGuesses = new List<char>();
            List<char> wrongGuessesLetters = new List<char>();
            
            while (!wordGuessed)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Please enter your guess: ");
                Console.ForegroundColor = ConsoleColor.White;
                string playerInput = Console.ReadLine();
                if (playerInput.Length > 1)
                {
                    if (playerInput == currentWord)
                    {
                        FullWordGuessedPrint(currentWord);
                        GuessedWords.Add(currentWord);
                        Highscore[user] += currentWord.Length * 15;
                        break;
                    }
                    else
                    {
                        InvalidInput();
                        continue;
                    }
                }
                char playerGuess = char.Parse(playerInput);
                if (currentWord.Contains(playerGuess))
                {
                    //the main code for the guessing game
                    #region
                    string wordForIndex = word.ToString(); 
                    // temp string to get the real index of the guessed char
                    int index = wordForIndex.IndexOf(playerGuess);
                    // the actual index 
                    if (index < 0)
                    {
                        Console.WriteLine(string.Join("",hiddenWord)); // current state of the guessed word
                        Console.WriteLine();
                        continue;
                    }
                    word[index] = '*';
                    //replacing the guessed char with *, so we are left only with the chars we need to guess 
                    hiddenWord[index] = playerGuess;
                    //placing the guessed char at the correct index into the char array
                    Console.WriteLine(string.Join("",hiddenWord)); // current state of the guessed word
                    Console.WriteLine();
                    #endregion
                }
                else
                {
                    loseCounter = WrongGuess(wrongGuesses, loseCounter, hiddenWord, wrongGuessesLetters, playerGuess);
                }

                if (loseCounter == 9)
                {
                    Failed(currentWord);
                    break;
                }
                if ((string.Join("",hiddenWord)) == currentWord)
                {
                    Success(currentWord);
                    GuessedWords.Add(currentWord);
                    Highscore[user] += currentWord.Length * 15;
                    wordGuessed = true;
                }
            }
        }

        public static void GetListGuessedWords()
        {
            int counter = 1;
            if(GuessedWords == null)
                Console.WriteLine("The list is empty !");
            else
            {
                foreach (var word in GuessedWords)
                {
                    Console.WriteLine($"{counter}. {word}");
                    counter++;
                }
            }
        }
        #region
        public static void FullWordGuessedPrint(string currentWord)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Congratulations. You guessed the word: \"");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(currentWord);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\" !");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public static void InvalidInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Please enter a valid input:  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("A single character or the full word !");
            Console.WriteLine();
        }

        public static int WrongGuess(List<char> wrongGuesses, int loseCounter, char[] hiddenWord,List<char> wrongGuessesLetters, char playerGuess)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Oops.. wrong guess, try again.");
            Console.ForegroundColor = ConsoleColor.White;
            wrongGuesses.Add('X');
            if(!wrongGuessesLetters.Contains(playerGuess))
            {
                wrongGuessesLetters.Add(playerGuess);
            }
            loseCounter++;
            Console.Write("Wrong guesses: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Join(" ",wrongGuesses));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Join(" ",wrongGuessesLetters));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Join("",hiddenWord));
            Console.WriteLine();
            return loseCounter;
        }

        public static void Failed(string currentWord)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You failed to guess the word.");
            Console.Write("The word was \"");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(currentWord);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\" :(");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Success(string currentWord)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Congratulations. You guessed the word: \"");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(currentWord);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\" !");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        #endregion
    }
}