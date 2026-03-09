// using System;

// class PerfectNumberCheck
// {
//     public static int CheckPerfectNumber(int input1)
//     {
//         if (input1 < 0)
//             return -2;

//         int sum = 0;

//         for (int i = 1; i <= input1 / 2; i++)
//         {
//             if (input1 % i == 0)
//                 sum += i;
//         }

//         if (sum == input1 && input1 != 0)
//             return 1;

//         return -1;
//     }

//     static void Main()
//     {
//         Console.WriteLine(CheckPerfectNumber(6));   
//         Console.WriteLine(CheckPerfectNumber(10));  
//         Console.WriteLine(CheckPerfectNumber(-5));  
//     }
// }
