class Program
{
    public static void Main(){
    int a=int.Parse(Console.ReadLine());
    int b=int.Parse(Console.ReadLine());
    int sum=0;
    for(int i=a;i<=b;i++){
        if(i%a==0){
            sum+=i;
        }
    }
    Console.Write(sum);
}}