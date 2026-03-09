class UserProgramCode{
    public static int LargestNumber(int[] arr){
        HashSet<int> unique = new HashSet<int>();
        foreach (int i in arr)
        {
            unique.Add(i);
        }
        int[] max = new int[10]; 

        foreach (int num in unique)
        {
            int index = (num - 1) / 10;
            if (num > max[index])
                max[index] = num;
        }

        int sum = 0;
        for (int i = 0; i < 10; i++)
        {
            sum += max[i];
        }

        return sum;
    }
}

class Program
{
    public static void Main(String[] args){
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        bool a=false;
        bool b = false;

        for(int i=0; i<n;i++){
            arr[i] = int.Parse(Console.ReadLine());
        }
        for(int i=0;i<n;i++){
            if(arr[i]<0){
                a=true;
            }
            else if(arr[i] > 100){
                b=true;
            }
        }
        if(a==true && b==true){
            Console.Write("-3");
            return ;
        }
        else if(a==true){
            Console.Write("-1");
            return;
        }
        else if(b==true){
            Console.Write("-2");
            return ;
        }
        else{
            UserProgramCode obj = new UserProgramCode();
            Console.Write(UserProgramCode.LargestNumber(arr));
            return;
        }
    }
}