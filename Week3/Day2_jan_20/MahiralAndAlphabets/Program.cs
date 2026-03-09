using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static bool IsVowel(char c)
    {
        c = char.ToLower(c);
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }

    static void Main()
    {
        string word1 = Console.ReadLine();
        string word2 = Console.ReadLine();

        HashSet<char> consonantsInWord2 = new HashSet<char>();

        foreach (char c in word2)
        {
            char lower = char.ToLower(c);
            if (!IsVowel(lower))
            {
                consonantsInWord2.Add(lower);
            }
        }

        StringBuilder filtered = new StringBuilder();

        foreach (char c in word1)
        {
            char lower = char.ToLower(c);

            if (IsVowel(lower) || !consonantsInWord2.Contains(lower))
            {
                filtered.Append(c);
            }
        }

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < filtered.Length; i++)
        {
            if (i == 0 || char.ToLower(filtered[i]) != char.ToLower(filtered[i - 1]))
            {
                result.Append(filtered[i]);
            }
        }

        Console.WriteLine(result.ToString());
    }
}
