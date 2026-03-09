using System;
using System.Collections.Generic;

namespace Hands_ON_Jan_9
{
	public class ElementMostNoOfTimes
	{
        static int[] FindMostRepeated(int[] input)
        {
            Array.Sort(input);

            List<int> result = new List<int>();

            int maxCount = 1;
            int currentCount = 1;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
                    currentCount++;
                else
                {
                    if (currentCount > maxCount)
                        maxCount = currentCount;

                    currentCount = 1;
                }
            }

            if (currentCount > maxCount)
                maxCount = currentCount;
            currentCount = 1;
            for (int i = 1; i <= input.Length; i++)
            {
                if (i < input.Length && input[i] == input[i - 1])
                {
                    currentCount++;
                }
                else
                {
                    if (currentCount == maxCount)
                        result.Add(input[i - 1]);

                    currentCount = 1;
                }
            }

            return result.ToArray();
        }
        static void Main()
        {
            int[] input1 = { 2, 2, 2, 2, 3, 3, 3, 3, 4 };
            int[] input2 = { 2, 2, 2, 3, 3, 4 };

            Console.WriteLine(string.Join(",", FindMostRepeated(input1)));
            Console.WriteLine(string.Join(",", FindMostRepeated(input2)));
        }
    }
}

