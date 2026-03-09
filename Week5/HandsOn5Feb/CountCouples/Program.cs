using System;

class CouplesDivisible
{
    static void Main()
    {
        Console.Write("Enter N (array size): ");
        int N = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[N];

        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < N; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        int count = 0;

        for (int i = 0; i < N - 1; i++)
        {
            if ((arr[i] + arr[i + 1]) % N == 0)
            {
                count++;
            }
        }

        Console.WriteLine("Total couples divisible by " + N + ": " + count);
    }
}
