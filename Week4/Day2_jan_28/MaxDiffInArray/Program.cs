class Program
{
    public static void Main(){
        Console.WriteLine("Enter the size of array: ");
        int n = int.Parse(Console.ReadLine());
        if(n==1 || n>10){
            Console.WriteLine("-2");
        }
        else{
            int[] arr = new int[n];
            for(int i=0;i<n;i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            foreach(int i in arr){
                if(i<0){
                    Console.WriteLine("-1");
                    return;
                }
            }
            for(int i=0;i<n;i++){
                for(int j=i+1;j<n;j++){
                    if(arr[i]==arr[j]){
                        Console.WriteLine("-1");
                        return ;
                    }
                }
            }
            UserProgramCode obj = new UserProgramCode();
            Console.WriteLine(obj.func(arr,n));
        }
    }
}