class Program
{
    static void Main()
    {
        char[] arr = { 'a', 'b', 'c', 'a', 'c', 'd' };

       for (int i = 0; i < arr.Length; i++)
{
    int count = 0;
    for (int j = 0; j < arr.Length; j++)
    {
        if (arr[i] == arr[j])
            count++;
    }

    if (count == 1)
    {
        Console.WriteLine(arr[i]);
        return;
    }
}

        Console.WriteLine("No non-repeating character found");
    }
}
