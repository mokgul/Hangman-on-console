using System;
using System.Collections.Generic;

namespace Hangman_CLI;

public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game("Words.txt");
        Menu menu = new Menu(game);
        
        int choice = -1;
        while (choice != 0)
        {
            menu.GetConsoleMenu();
            choice = Extensions.ReadUserInput();

            menu.ExecuteOption(choice);
        }
    }
}
