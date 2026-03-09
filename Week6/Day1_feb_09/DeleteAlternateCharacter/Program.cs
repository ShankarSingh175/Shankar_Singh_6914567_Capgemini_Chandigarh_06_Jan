class Program
{
    public static void Main(){
        string str = Console.ReadLine();
        string output = "";
        for(int i=0;i<str.Length;i++){
            if(i%2==0){
                output+=str[i];
            }
        }
        Console.WriteLine(output);
    }
}