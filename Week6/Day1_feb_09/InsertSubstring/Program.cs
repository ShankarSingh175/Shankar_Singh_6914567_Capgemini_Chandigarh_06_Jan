class Program
{
    public static void Main(){
        string str = Console.ReadLine();
        string insert = Console.ReadLine();
        int index = int.Parse(Console.ReadLine());
        char[] arr = str.ToCharArray();
        string answer = "";
        for(int i=0;i<arr.Length;i++){
            if(i==index){
                answer+=insert;
            }
            answer+=arr[i];
        }
        Console.WriteLine(answer);
    }
}