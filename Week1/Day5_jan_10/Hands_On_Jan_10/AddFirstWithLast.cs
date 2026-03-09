
// class AddFirstWithLast
// {
//     public int[] func(int[] input1, int[] input2, int input3)
//     {
//         if (input3 < 0)
//         {
//             return new int[] { -2 };
//         }

//         int[] output = new int[input3];

//         for (int i = 0; i < input3; i++)
//         {
//             if (input1[i] < 0 || input2[i] < 0)
//             {
//                 output[0] = -1;
//                 return output;
//             }
//         }
//         for (int i = 0; i < input3; i++)
//         {
//             output[i] = input1[i] + input2[input3 - 1 - i];
//         }

//         return output;
//     }

//     public static void Main()
//     {
//         int[] input1 = { 21, 23, 41, 4 };
//         int[] input2 = { 3, 4, 1, 5 };
//         int input3 = 4;

//         AddFirstWithLast obj = new AddFirstWithLast();
//         int[] result = obj.func(input1, input2, input3);

//         Console.WriteLine(string.Join(",", result));
//     }
// }
