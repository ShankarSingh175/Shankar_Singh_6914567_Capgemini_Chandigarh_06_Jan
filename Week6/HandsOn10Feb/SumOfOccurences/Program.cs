using System;
using System.Linq;

class ListDifference
{
    static void Main()
    {
        Console.Write("Enter the first list of integers (comma-separated): ");
        int[] list1 = Console.ReadLine()
                            .Split(',')
                            .Select(int.Parse)
                            .ToArray();

        Console.Write("Enter the second list of integers (comma-separated): ");
        int[] list2 = Console.ReadLine()
                            .Split(',')
                            .Select(int.Parse)
                            .ToArray();

        foreach (int n in list1.Distinct())
        {
            int sumOccurrences = list2.Where(x => x == n).Sum();
            Console.WriteLine($"{n}-{sumOccurrences}");
        }
    }
}
