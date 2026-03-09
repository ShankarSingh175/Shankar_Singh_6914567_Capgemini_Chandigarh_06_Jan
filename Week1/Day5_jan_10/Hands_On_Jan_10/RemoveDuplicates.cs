// using System;

// class RemoveDuplicates
// {
//     public int[] func(int[] input1, int input2)
//     {
//         if (input2 < 0)
//         {
//             return new int[] { -2 };
//         }

//         int[] temp = new int[input2];
//         int count = 0;

//         for (int i = 0; i < input2; i++)
//         {
//             if (input1[i] < 0)
//             {
//                 return new int[] { -1 };
//             }

//             bool isDuplicate = false;
//             for (int j = 0; j < count; j++)
//             {
//                 if (temp[j] == input1[i])
//                 {
//                     isDuplicate = true;
//                     break;
//                 }
//             }
//             if (!isDuplicate)
//             {
//                 temp[count] = input1[i];
//                 count++;
//             }
//         }

//         int[] output = new int[count];
//         for (int i = 0; i < count; i++)
//         {
//             output[i] = temp[i];
//         }

//         return output;
//     }

//     public static void Main()
//     {
//         int[] input1 = { 1, 2, 2, 3, 3 };
//         int input2 = 5;

//         RemoveDuplicates obj = new RemoveDuplicates();
//         int[] result = obj.func(input1, input2);

//         Console.WriteLine(string.Join(",", result));
//     }
// }
