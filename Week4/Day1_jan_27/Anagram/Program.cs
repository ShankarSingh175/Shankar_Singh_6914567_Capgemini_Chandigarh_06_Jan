using System;

class Program
{
    static void Main()
    {
        string s1 = "listen";
        string s2 = "silent";

        char[] a = s1.ToCharArray();
        char[] b = s2.ToCharArray();

        Array.Sort(a);
        Array.Sort(b);

        Console.WriteLine(new string(a) == new string(b)
            ? "Anagram"
            : "Not Anagram");
    }
}
