class Program
{
    static void Main()
    {
        int X = int.Parse(Console.ReadLine());
        int Y = int.Parse(Console.ReadLine());
        int N1 = int.Parse(Console.ReadLine());
        int N2 = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());

        bool isValid = false;
        int type1 = 0, type2 = 0;

        for (int a = N1; a >= 0; a--)
        {
            int remaining = M - (a * X);
            if (remaining < 0) continue;

            if (remaining % Y == 0)
            {
                int b = remaining / Y;
                if (b <= N2)
                {
                    type1 = a;
                    type2 = b;
                    isValid = true;
                    break;
                }
            }
        }

        if (isValid)
        {
            Console.WriteLine("Valid");
            Console.WriteLine(type1);
            Console.WriteLine(type2);
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    }
}
