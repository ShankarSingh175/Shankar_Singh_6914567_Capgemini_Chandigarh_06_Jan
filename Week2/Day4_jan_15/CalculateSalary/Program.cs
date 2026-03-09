class Program
{
    public static void Main(){
        int basic=int.Parse(Console.ReadLine());
        if(basic<0){
            Console.Write("-1");
        }
        else if(basic>10000){
            Console.Write("-2");
        }
        else{
            int days=int.Parse(Console.ReadLine());
            if(days>31){
                Console.Write("-3");
                return;
            }
            Salary obj = new Salary();
            obj.func(basic);
        }
    }
}