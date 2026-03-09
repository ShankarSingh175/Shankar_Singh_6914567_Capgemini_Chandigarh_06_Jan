using System;
using Internal;

namespace Hands_On_Jan_8
{
	public class Question02
	{
        public static void Main(String[] args)
        {
            Console.Write("Enter marks: ");
            int marks = int.Parse(Console.ReadLine());

            if (marks >= 90)
            {
                Console.WriteLine("Grade: A");
            }
            else if (marks >= 80)
            {
                Console.WriteLine("Grade: B");
            }
            else if (marks >= 70)
            {
                Console.WriteLine("Grade: C");
            }
            else if (marks >= 50)
            {
                Console.WriteLine("Grade: D");
            }
            else
            {
                Console.WriteLine("Grade: F");
            }
        }
    }
}