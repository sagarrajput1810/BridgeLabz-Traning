using System;
class SnakeAndLadder
{
    static void Main()
    {
        Console.WriteLine("Welcome to Snake and Ladder Game!");
        Console.WriteLine("Enter number of players:");
        int p = int.Parse(Console.ReadLine());
        int[] points = new int[p];
        while(true)
        {
            for(int i = 0; i < p; i++)
            {
                points[i] = Board(i + 1, points[i]);
                if(points[i] == 100)
                {
                    Console.WriteLine("Player" + (i + 1) + " wins the game!");
                    return;
                }
            }
        }
        
    }
    static int Board(int player, int position)
{
    Console.WriteLine("Enter for roll the dice player " + player);
    Console.ReadLine();

    Random random = new Random();
    int dice = random.Next(1, 7);

    if (position + dice <= 100)
    {
        if (dice + position == 99)
        {
            position = 6;
            Console.WriteLine("Oops! Snake bitten you.");
        }
        else if (dice + position == 97)
        {
            position = 84;
            Console.WriteLine("Oops! Snake bitten you.");
        }
        else if (dice + position == 94)
        {
            position = 71;
            Console.WriteLine("Oops! Snake bitten you.");
        }
        else if (dice + position == 77)
        {
            position = 28;
            Console.WriteLine("Oops! Snake bitten you.");
        }
        else if (dice + position == 37)
        {
            position = 7;
            Console.WriteLine("Oops! Snake bitten you.");
        }
        else if (dice + position == 10)
        {
            position = 61;
            Console.WriteLine("Yay! You climbed a ladder.");
        }
        else if (dice + position == 18)
        {
            position = 51;
            Console.WriteLine("Yay! You climbed a ladder.");
        }
        else if (dice + position == 30)
        {
            position = 87;
            Console.WriteLine("Yay! You climbed a ladder.");
        }
        else if (dice + position == 58)
        {
            position = 98;
            Console.WriteLine("Yay! You climbed a ladder.");
        }
        else
        {
            position += dice;
        }
    }

    Console.WriteLine("Player " + player + " rolled a " + dice + " and moved to position " + position);
    Console.WriteLine();

    return position;
}
}