class Program{
    public static void Main(){
        int a = int.Parse(Console.ReadLine());
        CountRupees obj = new CountRupees();
        Console.Write(obj.func(a));
    }
}