class Program
{
    public static void Main(){
        int n= int.Parse(Console.ReadLine());
        if(n<0){
            Console.Write("01");
            return;
        }
        else{
            int[] arr = new int[n];
            for(int i=0;i<n;i++){
                arr[i] = int.Parse(Console.ReadLine());
            }
            int a=int.Parse(Console.ReadLine());
            UserProgramCode obj = new UserProgramCode();
            int[] output = obj.func(arr,n,a);
            foreach (int item in output)
            {
                Console.WriteLine(item);
            }
        }
    }
}