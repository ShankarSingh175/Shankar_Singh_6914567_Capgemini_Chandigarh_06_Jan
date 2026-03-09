using System;
using Internal;

namespace Hands_On_Jan_8
{
	public class Question04
	{
        public static void Main()
        {
            Console.WriteLine("What is the correct way to declare a variable to store an integer value in C#?");
            Console.WriteLine("a. int 1x = 10;");
            Console.WriteLine("b. int x = 10;");
            Console.WriteLine("c. float x = 10.01;");
            Console.WriteLine("d. string x = \"10\";");

            Console.Write("Choose the answer letter: ");
            char answer = char.ToLower(Console.ReadKey().KeyChar);

            Console.WriteLine();

            if (answer == 'b')
            {
                Console.WriteLine("Correct ");
            }
            else
            {
                Console.WriteLine("Incorrect ");
            }

        }
    }
}

