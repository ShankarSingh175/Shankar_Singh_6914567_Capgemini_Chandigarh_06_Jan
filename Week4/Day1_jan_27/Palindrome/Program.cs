class Program
{
    public static void Main(string[] args){
        String str = Console.ReadLine();
        String rev = "";
        for(int i=str.Length-1;i>=0;i--){
            rev+=str[i];
        }
        if(rev == str){
            Console.Write("Palindrome");
        }
        else{
            Console.Write("Not a Palindrome");
        }
    }
}