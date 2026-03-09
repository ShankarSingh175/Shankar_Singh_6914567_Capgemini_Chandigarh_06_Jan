// class MultipleOfThree{
//     public static void Main(){
//     int n = int.Parse(Console.ReadLine());
//     int output=0;
//     if(n<0){
//         output=-2;
//         Console.WriteLine(output);
//     }
//     else{int[] arr = new int[n];
//     for(int i=0;i<n;i++){
//         arr[i]=int.Parse(Console.ReadLine());
//     }
//     for(int i=0;i<n;i++){
//         if(arr[i]<0){
//             output=-1;
//             Console.WriteLine(output);
//             return;
//         }
//     }
//     for(int i=0;i<n;i++){
//         if(arr[i]%3==0){
//             output++;
//         }
//     }
//     Console.WriteLine(output);
// }}}