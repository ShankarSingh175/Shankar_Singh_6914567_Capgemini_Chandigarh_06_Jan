using System;

class ScoreArray
{
    static void Main()
    {
        Console.Write("Enter array elements (comma-separated): ");
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(','), int.Parse);

        int score = 0;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            int sum = arr[i] + arr[i + 1];
            if (sum % 2 == 0)
                score += 5;
        }

        for (int i = 0; i < arr.Length - 2; i++)
        {
            int sum = arr[i] + arr[i + 1] + arr[i + 2];
            int product = arr[i] * arr[i + 1] * arr[i + 2];

            if (sum % 2 != 0 && product % 2 == 0)
                score += 10;
        }

        Console.WriteLine("Final Score: " + score);
    }
}
