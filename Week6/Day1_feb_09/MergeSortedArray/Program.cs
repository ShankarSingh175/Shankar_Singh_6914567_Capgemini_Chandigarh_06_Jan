class Program
{
    public static void Main(){
        int[] arr1 = {1,2,3,4,5};
        int[] arr2 = {6,7,8,9,10};
        int n = arr1.Length+arr2.Length;
        int[] arr = new int[n];
        for(int i =0 ;i<arr1.Length;i++){
            arr[i] = arr1[i];
        }
        for(int i=0;i<arr2.Length;i++){
            arr[arr1.Length+i]=arr2[i];
        }
        foreach (int item in arr)
        {
            Console.Write(item);
        }
    }
}