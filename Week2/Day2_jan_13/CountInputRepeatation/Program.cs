class Program{
    public static void Main(){
        int n = int.Parse(Console.ReadLine());
        if(n<0){
            Console.WriteLine("-2");
        }
        else{
            int[] arr = new int[n];
            for(int i=0;i<n;i++){
                arr[i]=int.Parse(Console.ReadLine());
            }
            for(int i=0;i<n;i++){
                if(arr[i]<0){
                    Console.WriteLine("-1");
                    return ;
                }
            }
            Console.WriteLine("Enter the Input:");
            int a=int.Parse(Console.ReadLine());
            if(a<0){
                Console.WriteLine("-3");
            }
            else{
                CountInputRepeatation obj = new CountInputRepeatation();
                Console.WriteLine(obj.func(arr,n,a));
            }
        }
    }
}