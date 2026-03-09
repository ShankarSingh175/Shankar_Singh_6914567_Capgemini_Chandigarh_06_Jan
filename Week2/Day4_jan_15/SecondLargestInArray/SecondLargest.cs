class SecondLargest{
    public void func(int[] arr,int n){
        int a=0;
        int b=0;
        Array.Sort(arr);
        for(int i=0;i<n;i++){
            if(arr[i]>a){
                b=a;
                a=arr[i];
            }
        }
        Console.Write(b);
    }
}