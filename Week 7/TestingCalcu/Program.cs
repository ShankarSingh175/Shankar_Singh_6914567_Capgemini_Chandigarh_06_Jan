public class Calculator {

    public int Add(int a, int b) => a+b;

    public int Subtract(int a, int b) => a-b;

    public int Multiply(int a, int b) => a*b;

    public double Divide(int a, int b) {
        if(b == 0) throw new DivideByZeroException("Cannot divide by Zero");
        return (double)a/b;
    } 

}

public class Program {

    public static void Main(string[] args) {

        try {
            Calculator cal = new Calculator();
            Console.WriteLine(cal.Add(10, 20));
            Console.WriteLine(cal.Subtract(20, 5));
            Console.WriteLine(cal.Multiply(10, 10));
            Console.WriteLine(cal.Divide(10, 0));
        }
        catch(Exception ex) {
            Console.WriteLine("Exception occured during division -> " + ex.Message);
        }
        
    }

}