class Program{
    public static void Main(){
        int n=int.Parse(Console.ReadLine());
        if(n<0){
            Console.Write("-2");
        }
        else{
            int[] arr=new int[n];
            int odd =0;
            int even=0;
            for(int i=0;i<n;i++){
                arr[i]=int.Parse(Console.ReadLine());
            }
            for(int i=0;i<n;i++){
                if(arr[i]<0){
                    Console.Write("-1");
                    return;
                }
            }
            for(int i=0;i<n;i++){
                if(arr[i]%2==0){
                    even+=arr[i];
                }
                else{
                    odd+=arr[i];
                }
            }
            Console.WriteLine((even+odd)/2);
        }
    }
}