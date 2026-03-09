using System;

class PalindromeCheck
{
    public static int CheckPalindrome(int input1)
    {
        if (input1 < 0)
        {
            return -1;
        }

        int original = input1;
        int reverse = 0;

        while (input1 > 0)
        {
            int digit = input1 % 10;
            reverse = reverse * 10 + digit;
            input1 /= 10;
        }

        if (original == reverse)
        {
            return 1;   
        }
        else
        {
            return -2;  
        }
    }

    static void Main()
    {
        int input1 = int.Parse(Console.ReadLine());
        int output1 = CheckPalindrome(input1);
        Console.WriteLine(output1);
    }
}
