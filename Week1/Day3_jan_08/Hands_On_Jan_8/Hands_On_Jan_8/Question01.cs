using System;
using Internal;

namespace Hands_On_Jan_8
{
	public class Question01
	{
        public static void Main(String[] args)
        {
            Console.Write("Enter no1: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Enter no2: ");
            int b = int.Parse(Console.ReadLine());

            Console.Write("Enter no3: ");
            int c = int.Parse(Console.ReadLine());

            int d;

            if (a >= b && a >= c)
            {
                d = a;
            }
            else if (b >= a && b >= c)
            {
                d = b;
            }
            else
            {
                d = c;
            }

            Console.WriteLine("Greatest no. is: " + d);

        }
    }
}

