
class LeapYearCheck
{
    public static int CheckLeapYear(int input1)
    {
        if (input1 < 0)
        {
            return -1;
        }

        if ((input1 % 400 == 0) || (input1 % 4 == 0 && input1 % 100 != 0))
        {
            return 1; 
        }
        else
        {
            return 0; 
        }
    }

    static void Main()
    {
        int input1 = int.Parse(Console.ReadLine());
        int output1 = CheckLeapYear(input1);
        Console.WriteLine(output1);
    }
}
