class MaxAndMin{
    public void func(int[] arr,int n){
        int max=arr[0];
        int min=arr[0];
        for(int i=1;i<n;i++){
            if(arr[i]>max){
                max=arr[i];
            }
            else if(arr[i]<min){
                min=arr[i];
            }
        }
        int Product=max*min;
        Console.WriteLine(Product);
    }
}