// using System;

// class SumOfCubeOfPrimes
// {
//     public static int Calculate(int n)
//     {
//         if (n < 0 || n > 7)
//             return -1;

//         int sum = 0;

//         for (int i = 2; i <= n; i++)
//         {
//             if (IsPrime(i))
//             {
//                 sum += i * i * i;
//             }
//         }

//         return sum;
//     }

//     static bool IsPrime(int num)
//     {
//         if (num <= 1)
//             return false;

//         for (int i = 2; i <= num / 2; i++)
//         {
//             if (num % i == 0)
//                 return false;
//         }

//         return true;
//     }

//     static void Main()
//     {
//         Console.WriteLine(Calculate(7));   
//         Console.WriteLine(Calculate(5));   
//         Console.WriteLine(Calculate(8));   
//         Console.WriteLine(Calculate(-3));  
//     }
// }
