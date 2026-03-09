using System;

class ClosestPerfectSquare
{
    static void Main()
    {
        Console.Write("Enter a positive integer: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int root = (int)Math.Sqrt(number);

        int lowerSquare = root * root;
        int upperSquare = (root + 1) * (root + 1);

        int closest = (number - lowerSquare <= upperSquare - number) 
                        ? lowerSquare 
                        : upperSquare;

        Console.WriteLine("Closest perfect square: " + closest);
    }
}
