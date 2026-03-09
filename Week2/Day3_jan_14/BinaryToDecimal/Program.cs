class Program{
    public static void Main(){
        int a = int.Parse(Console.ReadLine());
        BinaryToDecimal obj = new BinaryToDecimal();
        Console.Write(obj.func(a));
    }
}