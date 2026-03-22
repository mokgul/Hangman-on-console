using System;

namespace Hangman_CLI;

public static class Prints
{
    private static readonly string MenuText = @"
 +++++++++++++++++++++++++++++++++++++++++++++++++++
                        MENU                        
 +++++++++++++++++++++++++++++++++++++++++++++++++++
 Start a new game                               :1
 Change Category                                :2
 View Progress                                  :3
 Categories Overview                            :4
 Game Statistics                                :5
 Highscores                                     :6
 Rules                                          :7
 Reset Progress                                 :8
 Credits                                        :9
 Exit the program                               :0
 +++++++++++++++++++++++++++++++++++++++++++++++++++
";
    private static readonly string Credits = @"
+++++++++++++++++++++++++++++++++++++++++++++++++++
                     CREDITS                      
+++++++++++++++++++++++++++++++++++++++++++++++++++

Game made by @Mokgul v1.1

Date Created: 8-8-2022
Date Updated: 12-1-2026
Reason for Update: Refactored and improved the game. 
                  Originally written early in my studies, 
                  now reflecting my progress in quality and design.

This game was made as a side project during my studies at Software University.

Time to complete: Between 8 and 10 hours.

Credits to:
✨ Kaiser DMC - menu layout, game rules, and other ideas ✨

Thank you for playing!

++++++++++++++++++++++++++++++++++++++++++++++++++
";

    public static void DisplayConsoleMenu()
    {
        Console.WriteLine();
        Console.Write(MenuText);
        Console.WriteLine(" Which option would you like to run?: ");
    }

    public static void DisplayCredits()
    {
	    Console.Clear();
	    Console.WriteLine(Credits);
    }

    public static void PrintGuess(string word, int currentAttempts, int attempts, Dictionary<char, bool> guessed)
    {
        Console.Clear();
        string Divider = "+++++++++++++++++++++++++++++++++++++++++++++++++++";

        Console.WriteLine(Divider);
        Console.WriteLine($" Word    : {word}");
        Console.Write(" Lives   : ");
        RenderHearts(attempts, currentAttempts);
        Console.WriteLine();
        PrintGuessedLetters(guessed);
        Console.WriteLine(Divider);
    }

    private static void PrintGuessedLetters(Dictionary<char, bool> guessed)
    {
        Console.Write(" Guesses : ");

        foreach (var (letter, isCorrect) in guessed)
        {
            Console.ForegroundColor = isCorrect
            ? ConsoleColor.Green   // correct guess
            : ConsoleColor.DarkRed; // wrong guess

            Console.Write(letter);
            Console.Write(" ");
        }

        Console.ResetColor();
        Console.WriteLine();
    }

    private static void RenderHearts(int maxAttempts, int currentAttempts)
    {
        for (int i = 1; i <= maxAttempts; i++)
        {
            if (i <= currentAttempts)
                Console.Write('\u2764' + " "); 
            else
                Console.Write("\U0001FA76");
        }
    }
}
