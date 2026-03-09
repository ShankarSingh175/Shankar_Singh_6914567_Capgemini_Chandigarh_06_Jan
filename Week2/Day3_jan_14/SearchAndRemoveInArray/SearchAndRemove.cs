class SearchAndRemove{
    public void func(int[] arr,int n, int a){
        List<int> ls = new List<int>();
        int count=0;
        for(int i=0;i<n;i++){
            if(arr[i]!=a){
                ls.Add(arr[i]);
                count++;
            }
        }
        if(count==n){
            Console.Write("-3");
        }
        else{
            ls.Sort();
            foreach(int i in ls){
                Console.WriteLine(i);
            }
        }
    }
}