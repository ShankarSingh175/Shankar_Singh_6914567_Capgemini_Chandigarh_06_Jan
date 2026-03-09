class SumOfPrimeNoInArray{
     static int SumOfPrimes(int[] input1, int input2)
    {
        if (input2 < 0)
            return -2;

        int sum = 0;
        bool primeFound = false;

        for (int i = 0; i < input2; i++)
        {
            if (input1[i] < 0)
                return -1;

            if (IsPrime(input1[i]))
            {
                sum += input1[i];
                primeFound = true;
            }
        }

        if (!primeFound)
            return -3;

        return sum;
    }

    static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;

        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
                return false;
        }

        return true;
    }
    public static void Main(){
        int[] input1 = { 1, 2, 3, 4, 5 };
        int input2 = 5;

        Console.WriteLine(SumOfPrimes(input1, input2));
    }
}