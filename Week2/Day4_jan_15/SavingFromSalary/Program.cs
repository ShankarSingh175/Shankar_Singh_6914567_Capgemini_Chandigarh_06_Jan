class Program{
    public static void Main(){
        int salary=int.Parse(Console.ReadLine());
        if(salary<0){
            Console.Write("-2");
        }
        else if(salary>9000){
            Console.Write("-1");
        }
        else{
            int days=int.Parse(Console.ReadLine());
            if(days<0){
                Console.Write("-3");
                return;
            }
            else if(days == 31){
                salary+=500;
            }
            SavingFromSalary obj = new SavingFromSalary();
            obj.func(salary);
        }
    }
}