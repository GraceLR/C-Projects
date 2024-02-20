
var randome = new Random();
var dice = new Dice(randome, 6);
var guessingGame = new GuessingGame(dice);

bool result = guessingGame.Play();

class GuessingGame
{
    private readonly Dice _dice;
    private const int InitialTries = 3;

    public GuessingGame(Dice dice)
    {
        _dice = dice;
    }

    public bool Play()
    {
        var diceRollResult = _dice.Roll();
        Console.WriteLine($"Dice rolled. Guess what number it shows in {InitialTries} tries.");

        int triesLeft = InitialTries;
        while (triesLeft > 0)
        {
            var guess = ConsoleReader.ReadInteger("Please enter a number:");
            if (guess == diceRollResult)
            {
                return true;
            }
            triesLeft--;
        }
        return false;
    }
}

public static class ConsoleReader
{
    public static int ReadInteger(string message)
    {
        int result;
        do
        {
            Console.WriteLine(message);
        }
        while (!int.TryParse(Console.ReadLine(), out result));
        return result;
    }
}

public class Dice
{
    private readonly Random _random;
    private readonly int SidesCount;

    public Dice(Random random, int sidesCount)
    {
        _random = random;
        SidesCount = sidesCount;
    }

    public int Roll() => _random.Next(1, SidesCount + 1);

    public void Describe() => Console.WriteLine($"This is a dice with {SidesCount} sides.");

}