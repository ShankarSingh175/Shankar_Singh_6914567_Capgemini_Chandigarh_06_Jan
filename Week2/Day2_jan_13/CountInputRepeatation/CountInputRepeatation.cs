class CountInputRepeatation{
    public int func(int[] arr, int n,int a){
        int count=0;
        for(int i=0;i<n;i++){
            if(arr[i]==a){
                count++;
            }
        }
        return count;
    }
}