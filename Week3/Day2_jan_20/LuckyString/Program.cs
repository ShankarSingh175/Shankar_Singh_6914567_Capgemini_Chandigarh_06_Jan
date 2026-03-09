using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string str = Console.ReadLine();

        if (n > str.Length)
        {
            Console.WriteLine("Invalid");
            return;
        }

        int required = n / 2;

        for (int i = 0; i <= str.Length - n; i++)
        {
            string sub = str.Substring(i, n);

            bool validChars = true;
            foreach (char c in sub)
            {
                if (c != 'P' && c != 'S' && c != 'G')
                {
                    validChars = false;
                    break;
                }
            }

            if (!validChars)
                continue;

            int count = 1;
            for (int j = 1; j < sub.Length; j++)
            {
                if (sub[j] == sub[j - 1])
                {
                    count++;
                    if (count >= required)
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
                }
                else
                {
                    count = 1;
                }
            }
        }

        Console.WriteLine("No");
    }
}
