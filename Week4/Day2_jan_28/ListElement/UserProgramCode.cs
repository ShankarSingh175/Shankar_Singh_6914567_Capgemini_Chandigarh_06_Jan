class UserProgramCode{
    public int[] func(int[] arr,int n ,int a){
        List<int> ls = new List<int>();
        for(int i = 0;i<n;i++){
            if(arr[i]<a){
                ls.Add(arr[i]);
            }
        }
        ls.Sort();
        ls.Reverse();
        return ls.ToArray();
    }
}