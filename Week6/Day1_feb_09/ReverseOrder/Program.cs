class Program
{
    public static void Main(){
        string str = Console.ReadLine();
        string[] arr = str.Split("|");
        string answer="";
        for(int i=arr.Length-1;i>=0;i--){
            answer+=arr[i]+" ";
        }
        Console.WriteLine(answer);
    }
}