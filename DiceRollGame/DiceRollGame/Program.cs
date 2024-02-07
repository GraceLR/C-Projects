
class GuessingGame
{
    private readonly Dice _dice;
    private readonly ConsoleReader _consoleReader;
    private const int InitialTries = 3;

    public GuessingGame(Dice dice)
    {
        _dice = dice;
    }

    public void Play()
    {
        var diceRollResult = _dice.Roll();
        Console.WriteLine($"Dice rolled. Guess what number it shows in {InitialTries} tries.");

        int triesLeft = InitialTries;
        while (triesLeft > 0)
        {
            var guess = _consoleReader.ReadInteger("Please enter a number:");
            triesLeft--;
        }
    }
}

public class ConsoleReader
{
    public int ReadInteger(string message)
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