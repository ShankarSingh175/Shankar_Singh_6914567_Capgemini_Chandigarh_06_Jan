class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] input1 = new string[n];

        for (int i = 0; i < n; i++)
        {
            input1[i] = Console.ReadLine();
        }

        int input2 = int.Parse(Console.ReadLine());

        int result = UserProgramCode.getDonation(input1, input2);
        Console.WriteLine(result);
    }
}