class Program
{
    public static void Main(){
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        if(a<0 || b<0){
            Console.Write("-1");
        }
        else{
            int c = int.Parse(Console.ReadLine());
            Operations obj = new Operations();
            obj.func(a,b,c);
        }
    }
}