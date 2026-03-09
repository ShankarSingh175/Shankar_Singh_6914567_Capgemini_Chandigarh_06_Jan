// See https://aka.ms/new-console-template for more information
class Program{
    public static void Main(){
        Console.WriteLine("Enter the size of array: ");
        int n=int.Parse(Console.ReadLine());
        if(n<0){
            Console.Write("-2");
        }
        else{
            int[] arr = new int[n];
            for(int i=0;i<n;i++){
                arr[i]=int.Parse(Console.ReadLine());
            }
            for(int i=0;i<n;i++){
                if(arr[i]<0){
                    Console.Write("-1");
                    return;
                }
            }
            Console.Write(SumOfMultipleOf5.func(arr,n));
        }
    }
}