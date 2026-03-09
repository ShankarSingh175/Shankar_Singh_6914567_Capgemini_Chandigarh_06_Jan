class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string[] str = { "listen", "silent", "hello", "world", "abc", "bca" };

        // Store sorted form of each word
        string[] sorted = new string[str.Length];

        for (int i = 0; i < str.Length; i++)
        {
            char[] arr = str[i].ToCharArray();
            Array.Sort(arr);
            sorted[i] = new string(arr);
        }

        List<string> result = new List<string>();

        // Check uniqueness
        for (int i = 0; i < sorted.Length; i++)
        {
            bool isUnique = true;

            for (int j = 0; j < sorted.Length; j++)
            {
                if (i != j && sorted[i] == sorted[j])
                {
                    isUnique = false;
                    break;
                }
            }

            if (isUnique)
                result.Add(str[i]); // add original word
        }

        // Print result
        foreach (string item in result)
        {
            Console.WriteLine(item);
        }
    }
}
