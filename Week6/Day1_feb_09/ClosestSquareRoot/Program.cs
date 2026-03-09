
class Program
{
    public static void Main(){
        int a = int.Parse(Console.ReadLine());
        int lower = (int)Math.Sqrt(a);
        int upper = (int)Math.Pow((lower+1),2);
        lower = (int)Math.Pow(lower,2);
        if(a-lower<upper-a){
            Console.WriteLine(lower);
        }
        else Console.WriteLine(upper);
    }
}