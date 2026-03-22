using System;

namespace Hangman_CLI;

public class Menu
{
    private Game _game;

	public Menu(Game game)
    {
        _game = game;
    }

    public void GetConsoleMenu() => Prints.DisplayConsoleMenu();

    public void ExecuteOption(int choice)
    {
        switch(choice)
        {
            case 0: Exit(); break;
            case 1: NewGame(); break;
            case 2: SwitchMode(); break;
            case 3: Progress(); break;
            case 4: CategoriesOverview(); break;
            case 5: Statistics(); break;
            case 6: Highscores(); break;
            case 7: Rules(); break;
            case 8: ResetProgress(); break;
            case 9: Credits(); break;
        }
    }

    private void Exit()
    {
        Console.Clear();
        Console.Write("Thank you for playing !");
        return;
    }

    private void NewGame()
    {
        Console.Clear();
        _game.GenerateWord();
        _game.PlayerGuessing();

        Console.WriteLine("Press any key..");
        Console.ReadLine();
    }

    private void SwitchMode()
    {
        Console.Clear();
        Console.WriteLine("Switch between different categories.");
    }

    private void Progress()
    {
        Console.Clear();
        Console.WriteLine("Show per category progress table.");
    }

    private void CategoriesOverview()
    {
        Console.Clear();
        Console.WriteLine("Show overall progress for all categories.");
    }

    private void Statistics()
    {
        Console.Clear();
        Console.WriteLine("Show player statistics like games played, win rate, etc.");
    }

    private void Highscores()
    {
        Console.Clear();
        Console.WriteLine("Show highscores.");
    }

    private void Rules()
    {
        Console.Clear();
        Console.WriteLine("Print game rules / how to play");
    }

    private void ResetProgress()
    {
        Console.Clear();
        Console.WriteLine("Reset game progress.");
    }

    private void Credits()
    {
        Console.Clear();
        Prints.DisplayCredits();
        Console.WriteLine("Press any key to return..");
        Console.ReadLine();
    }
}
