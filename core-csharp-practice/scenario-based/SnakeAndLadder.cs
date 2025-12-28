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

    static int Board(int p, int point)
    {
        Console.WriteLine("Enter for roll the dice player"+ p);
        Console.ReadLine();
        Random random = new Random();
        int dice = random.Next(1, 7);
        if(point + dice < 100)
        {
            if(dice + point == 99)
            {
                point = 6;
                Console.WriteLine("Oops! Snake bitten you.");
            }
            else if(dice + point == 97)
            {
                point = 84;
                Console.WriteLine("Oops! Snake bitten you.");
            }
            else if(dice + point == 94)
            {
                point = 71;
                Console.WriteLine("Oops! Snake bitten you.");
            }
            else if(dice + point == 77)
            {
                point = 28;
                Console.WriteLine("Oops! Snake bitten you.");
            }
            else if(dice + point == 37)
            {
                point = 7;
                Console.WriteLine("Oops! Snake bitten you.");
            }
            else if(dice + point == 10)
            {
                point = 61;
                Console.WriteLine("Yay! You climbed a ladder.");
            }
            else if(dice + point == 18)
            {
                point = 51;
                Console.WriteLine("Yay! You climbed a ladder.");
            }
            else if(dice + point == 30)
            {
                point = 87;
                Console.WriteLine("Yay! You climbed a ladder.");
            }
            else if(dice + point == 58)
            {
                point = 98;
                Console.WriteLine("Yay! You climbed a ladder.");
            }
            else
            {
                point += dice;
            }

        }
        Console.WriteLine("Player" + p + " rolled a " + dice + " and moved to position " + point);
        Console.WriteLine();
        return point;
    }
}