class Program
{
    public static void Main(){
    int n = int.Parse(Console.ReadLine());
    int[] arr = new int[n];
    int Count=0;
    for(int i =0;i<n;i++){
        arr[i] = int.Parse(Console.ReadLine());
    }
    for(int i=0;i<n-1;i++){
        if((arr[i]+arr[i+1])%n==0){
            Count++;
        }
    }
    Console.WriteLine(Count);
    }
}