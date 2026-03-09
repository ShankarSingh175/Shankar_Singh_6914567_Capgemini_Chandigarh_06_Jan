class Program
{
    public static bool isPalindrome(string str)
    {
        for (int i = 0; i < str.Length / 2; i++)
        {
            if (str[i] != str[str.Length - i - 1])
                return false;
        }
        return true;
    }

    public static void Main()
    {
        string str = Console.ReadLine();
        int score = 0;

        for (int i = 0; i < str.Length; i++)
        {
            if (i <= str.Length - 4)
            {
                if (isPalindrome(str.Substring(i, 4)))
                    score += 5;
            }

            if (i <= str.Length - 5)
            {
                if (isPalindrome(str.Substring(i, 5)))
                    score += 10;
            }
        }

        Console.WriteLine(score);
    }
}
