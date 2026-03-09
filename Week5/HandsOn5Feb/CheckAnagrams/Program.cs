using System;
using System.Linq;

class CheckAnagrams
{
    static void Main()
    {
        Console.Write("Enter comma separated words: ");
        string input = Console.ReadLine();

        string[] words = input.Split(',');

        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].Trim().ToLower();
        }

        string baseWord = String.Concat(words[0].OrderBy(c => c));

        bool isAnagram = true;

        for (int i = 1; i < words.Length; i++)
        {
            string sortedWord = String.Concat(words[i].OrderBy(c => c));

            if (sortedWord != baseWord)
            {
                isAnagram = false;
                break;
            }
        }

        Console.WriteLine(isAnagram ? "true" : "false");
    }
}
