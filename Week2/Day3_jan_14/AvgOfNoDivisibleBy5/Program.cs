class Program{
    public static void Main(){
    int a = int.Parse(Console.ReadLine());
    if(a<0){
        Console.Write("-1");
    }
    else{
        avg obj = new avg();
        Console.WriteLine(obj.func(a));
    }
}}