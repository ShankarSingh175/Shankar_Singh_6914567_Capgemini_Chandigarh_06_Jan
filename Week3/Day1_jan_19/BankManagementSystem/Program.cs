class Account{
    public int balance=10000;
    public int accNo;
    public Account(int accNo){
        this.accNo=accNo;
    }
    public void display(){
        Console.WriteLine("Balance of "+accNo+" is: "+balance);
    }
}
class Savings: Account{
    public Savings(int accNo) : base(accNo) { }
    public int year;
    public void Interest(int year){
        this.year =year;
        int interest = ((balance*4*year)/100);
        Console.WriteLine("Interest on balance for "+year+" years is: "+interest);
    }
    public void type(){
        Console.WriteLine("Saving Account");
    }
}
class Checking:Account{
    public Checking(int accNo) : base(accNo) { }
    public void type(){
        Console.WriteLine("Checking Account");
    }
}
class Business:Account{
    public Business(int accNo) : base(accNo) { }
    public void type(){
        Console.WriteLine("Business Account");
    }
}
class Program
{
    public static void Main(String[] args){
        Console.WriteLine("Enter ur Account Number: ");
        int accNo=int.Parse(Console.ReadLine());
        Console.WriteLine("Which type of account do u own!");
        Console.WriteLine("1. Savings");
        Console.WriteLine("2. Checking");
        Console.WriteLine("3. Business");
        Console.Write("Type your option: ");
        int option=int.Parse(Console.ReadLine());
        switch (option)
        {
            case 1:
            Savings obj=new Savings(accNo);
            obj.type();
            Console.WriteLine("Enter number of years for the calculation of interest");
            int year = int.Parse(Console.ReadLine());
            obj.display();
            obj.Interest(year);
            Console.WriteLine("Type 1. For Withdrawal");
            Console.WriteLine("Type 2. For Deposit");
            int a=int.Parse(Console.ReadLine());
            switch (a){
                case 1:
                Console.WriteLine("Enter the amount you want to Withdraw: ");
                int Withdrawal=int.Parse(Console.ReadLine());
                obj.balance-=Withdrawal;
                obj.display();
                break;
                case 2:
                Console.WriteLine("Enter the amount you want to deposit: ");
                int Deposit=int.Parse(Console.ReadLine());
                obj.balance+=Deposit;
                obj.display();
                break;
                default:
                Console.Write("Exited!");
                break;
            }
            break;
            case 2:
            Checking obj1=new Checking(accNo);
            obj1.type();
            obj1.display();
            Console.WriteLine("Type 1. For Withdrawal");
            Console.WriteLine("Type 2. For Deposit");
            int b=int.Parse(Console.ReadLine());
            switch (b){
                case 1:
                Console.WriteLine("Enter the amount you want to Withdraw: ");
                int Withdrawal=int.Parse(Console.ReadLine());
                obj1.balance-=Withdrawal;
                obj1.display();
                break;
                case 2:
                Console.WriteLine("Enter the amount you want to deposit: ");
                int Deposit=int.Parse(Console.ReadLine());
                obj1.balance+=Deposit;
                obj1.display();
                break;
                default:
                Console.Write("Exited!");
                break;
            }
            break;
            case 3:
            Business obj2=new Business(accNo);
            obj2.type();
            obj2.display();
            Console.WriteLine("Type 1. For Withdrawal");
            Console.WriteLine("Type 2. For Deposit");
            int c=int.Parse(Console.ReadLine());
            switch (c){
                case 1:
                Console.WriteLine("Enter the amount you want to Withdraw: ");
                int Withdrawal=int.Parse(Console.ReadLine());
                obj2.balance-=Withdrawal;
                obj2.display();
                break;
                case 2:
                Console.WriteLine("Enter the amount you want to deposit: ");
                int Deposit=int.Parse(Console.ReadLine());
                obj2.balance+=Deposit;
                obj2.display();
                break;
                default:
                Console.Write("Exited!");
                break;

            }
            break;
            default:
            Console.WriteLine("Invalid Choice");
            break;
        }
    }
}