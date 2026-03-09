class Program{
    public static void Main(){
        int n = int.Parse(Console.ReadLine());
        if(n<0){
            Console.WriteLine("-2");
        }
        else{
            int[] arr1 = new int[n];
            for(int i=0;i<n;i++){
                arr1[i] = int.Parse(Console.ReadLine());
            }
            int[] arr2 = new int[n];
            for(int i=0;i<n;i++){
                arr2[i] = int.Parse(Console.ReadLine());
            }
            for(int i=0;i<n;i++){
                if(arr1[i]<0 || arr2[i]<0){
                    Console.WriteLine("-1");
                    return;
                }
            }
            SumOfArray obj = new SumOfArray();
            obj.func(arr1,arr2,n);
        }
    }
}