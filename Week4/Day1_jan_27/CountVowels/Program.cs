class Program
{
    public static void Main(){
        String str = Console.ReadLine();
        int count= 0;
        for(int i=0;i<str.Length;i++){
            if(str[i]=='a' || str[i]=='e' || str[i]=='i' || str[i]=='o' || str[i]=='u'){
                count++;
            }
        }
        Console.Write(count);
    }
}