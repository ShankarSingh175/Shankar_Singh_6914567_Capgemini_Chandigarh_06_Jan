using System;

class MaxDeletions
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string s = Console.ReadLine();

        int maxDeletions = s.Length / 2;

        Console.WriteLine("Maximum deletions possible: " + maxDeletions);
    }
}
