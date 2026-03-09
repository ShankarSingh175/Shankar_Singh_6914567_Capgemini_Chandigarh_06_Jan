// class ProductDivisibleBy3or5{
//     public static void Main(){
//         int a = int.Parse(Console.ReadLine());
//         int b=1;
//         if(a<0){
//             b=-1;
//             Console.WriteLine(b);
//         }
//         else if(a%3==0 || a%5==0){
//             b=-2;
//             Console.WriteLine(b);
//         }
//         else{
//             int temp = a,product=1;
//             while(temp>0){
//                 int digit = temp%10;
//                 product*=digit;
//                 temp/=10;
//             }
//             if(product%3==0 || product%5==0){
//                 Console.WriteLine(b);
//             }
//         }
//     }
// }