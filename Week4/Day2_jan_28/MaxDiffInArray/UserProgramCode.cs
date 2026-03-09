class UserProgramCode{
    public int func(int[] arr , int n){
        int min =arr[0];
        int MaxDiff=0;
        for(int i=1;i<n;i++){
            if(min>arr[i]){
                min=arr[i];
            }
            int diff=arr[i]-min;
            if(diff>MaxDiff){
                MaxDiff=diff;
            }
        }
        return MaxDiff;
    }
}