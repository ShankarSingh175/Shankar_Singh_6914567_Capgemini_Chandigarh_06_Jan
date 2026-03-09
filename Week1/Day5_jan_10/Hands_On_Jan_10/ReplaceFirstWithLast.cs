// using System;

// class ReplaceFirstWithLast
// {
//     public int[] func(int[] input1, int input2)
//     {
//         if (input2 < 0)
//         {
//             return new int[] { -2 };
//         }

//         int[] output = new int[input2];

//         if (input2 % 2 == 0)
//         {
//             output[0] = -3;
//             return output;
//         }

//         for (int i = 0; i < input2; i++)
//         {
//             if (input1[i] < 0)
//             {
//                 output[0] = -1;
//                 return output;
//             }
//         }

//         int mid = input2 / 2; 

//         for (int i = 0; i < input2; i++)
//         {
//             output[i] = input1[input2 - 1 - i];
//         }

//         return output;
//     }

//     public static void Main()
//     {
//         int[] input1 = { 12, 34, 56, 17, 2 };
//         int input2 = 5;

//         ReplaceFirstWithLast obj = new ReplaceFirstWithLast();
//         int[] result = obj.func(input1, input2);

//         Console.WriteLine(string.Join(",", result));
//     }
// }