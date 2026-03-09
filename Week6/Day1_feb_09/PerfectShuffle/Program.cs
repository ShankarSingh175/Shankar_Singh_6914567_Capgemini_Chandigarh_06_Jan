using System;

class Program
{
    public static void Main()
    {
        string x = Console.ReadLine();
        string y = Console.ReadLine();
        string z = Console.ReadLine();

        if (z.Length != x.Length + y.Length)
        {
            Console.WriteLine("Not a perfect shuffle");
            return;
        }

        int px = 0;
        int py = 0;

        for (int i = 0; i < z.Length; i++)
        {
            if (px < x.Length && z[i] == x[px])
            {
                px++;
            }
            else if (py < y.Length && z[i] == y[py])
            {
                py++;
            }
            else
            {
                Console.WriteLine("Not a perfect shuffle");
                return;
            }
        }

        if (px == x.Length && py == y.Length)
            Console.WriteLine("Perfect Shuffle");
        else
            Console.WriteLine("Not a perfect shuffle");
    }
}
