class Program
{
    public static void Main(){
        string str = Console.ReadLine();
        string ch = Console.ReadLine();
        string replace = Console.ReadLine();
        string[] arr = str.Split(" ");
        int index = -1;
        for(int i=0;i<arr.Length;i++){
            if(arr[i].EndsWith(ch)){
                index = i;
                break;
            }
        }
        string answer="";
        for(int i=0;i<arr.Length;i++){
            if(i!=index){
                answer+=arr[i]+" ";
            }
            else if(i==index) answer+=arr[i].Replace(ch,replace)+" ";
        }
        Console.WriteLine(answer);
    }
}