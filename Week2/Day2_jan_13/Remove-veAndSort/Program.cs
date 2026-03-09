class Program{
    public static void Main(){
    int n = int.Parse(Console.ReadLine());
    if(n<0){
        Console.Write("-1");
    }
    else{
        int[] arr=new int[n];
        for(int i=0;i<n;i++){
            arr[i]=int.Parse(Console.ReadLine());
        }
        RemoveAndSort obj=new RemoveAndSort();
        List<int> ls =new List<int>();
        ls= obj.func(arr,n);
        foreach (int i in ls)
        {
            Console.WriteLine(i);
        }
        }
}}