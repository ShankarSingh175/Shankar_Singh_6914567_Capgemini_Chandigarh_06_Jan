class Program{
    public static void Main(){
        int a = int.Parse(Console.ReadLine());
        if(a<0){
            Console.Write("-1");
        }
        else{
            SumOfSquareOddDigits obj = new SumOfSquareOddDigits();
            Console.Write(obj.func(a));
        }
    }
}