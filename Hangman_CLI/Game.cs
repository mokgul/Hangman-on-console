namespace Hangman_CLI;

public class Game
{
    private List<string> _words;
    private int _count;
    
    private Random _r = new Random();
    
    private string _currentWord = "";
    private int _attempts = 9;
    private bool isPlaying = false;

    public Game(string file)
    {
        _words = Extensions.ReadFile(file);
        _count = _words.Count();
    }
    
    public void Start()
    {
        GenerateWord();
        PlayerGuessing();
    }
    
    public void GenerateWord()
    {
        int index = _r.Next(_count);
        string word = _words[index];
        isPlaying = true;
        _currentWord = word;
        Console.WriteLine(word);
    }

    public void PlayerGuessing()
    {
        string guessWord = new string('*', _currentWord.Length);
        int currentAttempts = _attempts;
        Dictionary<char, bool> guessed = new Dictionary<char, bool>();

        while (isPlaying)
        {
            char guess = Extensions.ReadUserGuess();
            if (!guessed.ContainsKey(guess))
                guessed.Add(guess, false);

            if (_currentWord.Contains(guess))
            {
                guessWord = ReplaceAllOccurances(guess, guessWord);
                guessed[guess] = true;
                Prints.PrintGuess(guessWord, currentAttempts, _attempts, guessed);
                Console.WriteLine("Good job, you guessed a character correctly.");
            }
            else
            {
                currentAttempts--;
                Prints.PrintGuess(guessWord, currentAttempts, _attempts, guessed);
                Console.WriteLine("Oops.. wrong guess, try again.");
            }

            if (_attempts - currentAttempts >= _attempts)
                isPlaying = false;
        }
    }

    private string ReplaceAllOccurances(char c, string guessWord)
    {
        char[] charArr = guessWord.ToCharArray();
        for (int i = 0; i < _currentWord.Length; i++)
        {
            if (_currentWord[i] == c)
            {
                charArr[i] = c;
            }
        }

        return new string(charArr);
    }
}
