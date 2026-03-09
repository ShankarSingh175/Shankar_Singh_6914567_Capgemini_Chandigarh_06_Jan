class SumOfMultipleOf5{
    public static int func(int[] arr, int n){
        int sum=0;
        for(int i=0;i<n;i++){
            if(arr[i]%5==0){
                sum+=arr[i];
            }
        }
        return sum;
    }
}