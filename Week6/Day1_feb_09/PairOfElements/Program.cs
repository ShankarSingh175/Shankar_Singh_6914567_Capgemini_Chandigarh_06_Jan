class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int num = int.Parse(Console.ReadLine());
        int a = -1;
        int b = -1;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)   
            {
                if (arr[i] + arr[j] == num)
                {
                    a = i;
                    b = j;
                    break;   
                }
            }
            if (a != -1) break;   
        }

        if (a != -1)
            Console.WriteLine(a + " " + b);
        else
            Console.Write("Not Found");
    }
}
