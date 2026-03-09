class DecimalToBinary
{
    public static int[] ConvertToBinary(int input1)
    {
        if (input1 < 0)
        {
            return new int[] { -1 };
        }

        if (input1 == 0)
        {
            return new int[] { 0 };
        }

        List<int> binaryList = new List<int>();

        while (input1 > 0)
        {
            binaryList.Add(input1 % 2);
            input1 /= 2;
        }
        binaryList.Reverse();

        return binaryList.ToArray();
    }

    public static void Main()
    {
        int input1 = 100;
        int[] output = ConvertToBinary(input1);

        Console.WriteLine(string.Join(",", output));
    }
}