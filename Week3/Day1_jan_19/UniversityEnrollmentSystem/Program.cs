class Person{
    public String name;
    public int age;
    public Person(String name,int age){
        this.name=name;
        this.age=age;
    }
}
class Student: Person{
    public Student(String name,int age) : base(name,age) { }
    public void display(){
    Console.WriteLine(name+" is enrolled as a student and age of the student is: "+age);}
}
class Staff:Person{
    public Staff(String name,int age) : base(name, age) { }
    public void display(){
        Console.WriteLine(name+" is enrolled in Non-Teaching Staff is: "+age);
    }
}
class Professor:Person{
    public Professor(String name,int age) : base(name,age) { }
    public void display(){
        Console.WriteLine("You are enrolled as Professor");
    }
    public void course(){
        Console.WriteLine("Choose the course you want:");
        Console.WriteLine("1. Maths");
        Console.WriteLine("2. Physics");
        Console.WriteLine("3. Biology");
        Console.WriteLine("4. Chemistry");
        Console.WriteLine("Enter your choice:");
        int a=int.Parse(Console.ReadLine());
        String Course;
        switch (a){
            case 1:
            Course="Maths";
            Console.WriteLine("You have assigned: "+Course);
            break;
            case 2:
            Course="Physics";
            Console.WriteLine("You have assigned: "+Course);
            break;
            case 3:
            Course="Biology";
            Console.WriteLine("You have assigned: "+Course);
            break;
            case 4:
            Course="Chemistry";
            Console.WriteLine("You have assigned: "+Course);
            break;
            default:
            Console.WriteLine("Invalid!");
            break;
        }
    }
}
class Program
{
    public static void Main(string[] args){
        String name=Console.ReadLine();
        int age=int.Parse(Console.ReadLine());
        Console.WriteLine("What you want to enrolled as: ");
        Console.WriteLine("1. Student");
        Console.WriteLine("2. Staff");
        Console.WriteLine("3. Professor");
        int b=int.Parse(Console.ReadLine());
        switch (b){
            case 1:
            Student obj = new Student(name,age);
            obj.display();
            break;
            case 2: 
            Staff obj1 = new Staff(name,age);
            obj1.display();
            break;
            case 3:
            Professor obj2= new Professor(name,age);
            obj2.display();
            obj2.course();
            break;
            default:
            Console.WriteLine("Invalid!");
            break;
        }
    }
}