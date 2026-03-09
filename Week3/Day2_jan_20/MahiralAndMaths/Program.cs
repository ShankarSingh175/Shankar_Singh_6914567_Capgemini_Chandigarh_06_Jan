class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int start = 10;
        if (start == N)
        {
            Console.WriteLine(0);
            return;
        }

        Queue<(int value, int steps)> queue = new Queue<(int, int)>();
        HashSet<int> visited = new HashSet<int>();

        queue.Enqueue((start, 0));
        visited.Add(start);

        int maxLimit = 3 * N + 10;

        while (queue.Count > 0)
        {
            var (current, steps) = queue.Dequeue();

            int[] nextStates = { current + 2, current - 1, current * 3 };

            foreach (int next in nextStates)
            {
                if (next == N)
                {
                    Console.WriteLine(steps + 1);
                    return;
                }

                if (next >= 0 && next <= maxLimit && !visited.Contains(next))
                {
                    visited.Add(next);
                    queue.Enqueue((next, steps + 1));
                }
            }
        }
    }
}
