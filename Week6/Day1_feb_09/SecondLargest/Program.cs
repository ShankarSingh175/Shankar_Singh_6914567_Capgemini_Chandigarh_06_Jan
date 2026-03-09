class Program
{
    public static void Main(){
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for(int i =0;i<n;i++){
            arr[i] = int.Parse(Console.ReadLine());
        }
        int first = arr[1];
        int second = arr[0];
        for(int i=1;i<n;i++){
            if(arr[i]>first){
                second=first;
                first = arr[i];
            }
            else if(second<arr[i]){
                second = arr[i];
            }
        }
        Console.WriteLine(second);
    }
}