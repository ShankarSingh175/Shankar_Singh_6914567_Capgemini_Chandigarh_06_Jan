class Program
{
    public static void Main(){
        string str = Console.ReadLine();
        string ch = Console.ReadLine();
        string[] arr = str.Split(" ");
        int index = -1;
        for(int i=arr.Length-1;i>=0;i--){
            if(arr[i]==ch){
                index = i;
                break;
            }
        }
        string answer="";
        for(int i=0;i<arr.Length;i++){
            if(i!=index){
                answer+=arr[i]+" ";
            }
        }
        Console.WriteLine(answer);
    }
}