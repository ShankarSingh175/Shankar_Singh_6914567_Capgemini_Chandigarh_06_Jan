using System;

class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] arr = new string[n];

        for (int i = 0; i < n; i++)
        {
            arr[i] = Console.ReadLine();
        }

        char ch = char.Parse(Console.ReadLine());

        int result = UserProgramCode.GetCount(n, arr, ch);

        if (result == -1)
            Console.WriteLine("No elements Found");
        else if (result == -2)
            Console.WriteLine("Only alphabets should be given");
        else
            Console.WriteLine(result);
    }
}
