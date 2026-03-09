class SearchElement{
    public int func(int[] arr,int n,int a){
        int index=-1;
        for(int i=0;i<n;i++){
            if(arr[i]==a){
                index=i;
            }
        }
        if(index>0){
        return 1;
        }
        else{
            return -3;
        }
    }
}