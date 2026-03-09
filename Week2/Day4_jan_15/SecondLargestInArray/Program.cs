class Program{
    public static void Main(){
        int n = int.Parse(Console.ReadLine());
        if(n<0){
            Console.WriteLine("-2");
        }
        else{
            int[] arr = new int[n];
            for(int i=0;i<n;i++){
                arr[i] = int.Parse(Console.ReadLine());
            }
            for(int i=0;i<n;i++){
                if(arr[i]<0){
                    Console.WriteLine("-1");
                    return;
                }
            }
            SecondLargest obj = new SecondLargest();
            obj.func(arr,n);
        }
    }
}