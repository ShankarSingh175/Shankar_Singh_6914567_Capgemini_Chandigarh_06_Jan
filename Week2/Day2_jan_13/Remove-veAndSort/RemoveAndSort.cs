class RemoveAndSort{
    public List<int> func(int[] arr,int n){
        List<int> a= new List<int>();
        for(int i=0;i<n;i++){
            if(arr[i]>=0){
                a.Add(arr[i]);
            }
        }
        return a;
    }
}