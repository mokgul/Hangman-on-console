using System;
using System.Collections.Generic;

namespace Hangman_CLI;

public static class Extensions
{
    public static int ReadUserInput()
    {
        int input;
        
        if (int.TryParse(Console.ReadLine(), out input))
            return input;
        else
            Console.WriteLine("Not a valid input. Please enter a number!");

        return ReadUserInput();
    }

    public static char ReadUserGuess()
    {
        char input;

        if (char.TryParse(Console.ReadLine(), out input))
            return input;
       else
            Console.WriteLine("Input is not a character. Please enter a single character!");

        return ReadUserGuess();
    }

    public static List<string> ReadFile(string file)
    {
        List<string> lines = new List<string>();
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "files", file);

        string line = "";
        try
        {
            StreamReader sr = new StreamReader(filePath);
            line = sr.ReadLine();

            while(line != null)
            {
                lines.Add(line);
                line = sr.ReadLine();
            }

            return lines;
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
            return lines;
        }
    }
}




