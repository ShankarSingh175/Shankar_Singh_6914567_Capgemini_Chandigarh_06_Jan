class SumOfArray{
    public void func(int[] arr1,int[] arr2,int n){
        int[] arr = new int[n];
        for(int i=0;i<n;i++){
            arr[i]=arr1[i]+arr2[n-i-1];
        }
        for(int i=0;i<n;i++){
            Console.WriteLine(arr[i]);
        }
    }
}