class SavingFromSalary{
    public void func(int salary){
        int Food=(salary)*50/100;
        Console.WriteLine("Salary expense is: "+Food);
        int Travel=(salary)*20/100;
        Console.WriteLine("Travel expense is: "+Travel);
        int Savings=(salary)*30/100;
        Console.WriteLine("Savings is: "+Savings);
    }
}
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