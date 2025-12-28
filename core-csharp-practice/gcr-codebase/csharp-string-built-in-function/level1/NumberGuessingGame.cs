using System;

class NumberGuessingGame
{
    static Random random = new Random();

    static void Main(string[] args)
    {
        int low = 1;
        int high = 100;
        bool guessedCorrectly = false;

        Console.WriteLine("Think of a number between 1 and 100.");

        while (!guessedCorrectly)
        {
            int guess = GenerateGuess(low, high);
            Console.WriteLine("Computer guess: " + guess);
            Console.Write("Is it High (H), Low (L), or Correct (C)? : ");
            char feedback = GetFeedback();

            if (feedback == 'C')
            {
                guessedCorrectly = true;
                Console.WriteLine("Computer guessed correctly!");
            }
            else if (feedback == 'H')
            {
                high = guess - 1;
            }
            else if (feedback == 'L')
            {
                low = guess + 1;
            }
        }
    }

    static int GenerateGuess(int low, int high)
    {
        return random.Next(low, high + 1);
    }

    static char GetFeedback()
    {
        return Char.ToUpper(Console.ReadLine()[0]);
    }
}
