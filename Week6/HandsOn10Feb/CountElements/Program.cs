using System;

class NonDivisibleCount
{
    static void Main()
    {
        Console.Write("Enter array elements (comma-separated): ");
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(','), int.Parse);

        int count = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            bool divisible = false;

            for (int j = 0; j < arr.Length; j++)
            {
                if (i != j && arr[i] % arr[j] == 0)
                {
                    divisible = true;
                    break;
                }
            }

            if (!divisible)
                count++;
        }

        Console.WriteLine("Total elements not divisible by others: " + count);
    }
}
