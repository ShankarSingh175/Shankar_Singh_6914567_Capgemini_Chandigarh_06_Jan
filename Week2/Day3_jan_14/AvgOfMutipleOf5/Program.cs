class Program{
    public static void Main(){
        int a=int.Parse(Console.ReadLine());
        if(a<0){
            Console.Write("-1");
        }
        else if(a>500){
            Console.Write("-2");
        }
        else{
            Avg obj = new Avg();
            Console.WriteLine(obj.func(a));
        }
    }
}