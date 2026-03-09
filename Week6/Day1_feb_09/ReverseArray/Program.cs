class Program
{
    public static void Main(){
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for(int i =0;i<n;i++){
            arr[i] = int.Parse(Console.ReadLine());
        }
        for(int i=0;i<n/2;i++){
            int temp = arr[n-i-1];
            arr[n-i-1] = arr[i];
            arr[i] = temp;
        }
        foreach (int item in arr)
        {
            Console.Write(item);
        }
    }
}