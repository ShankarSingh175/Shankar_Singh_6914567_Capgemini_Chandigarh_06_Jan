// See https://aka.ms/new-console-template for more information
class Program{
    public static void Main(){
        int a = int.Parse(Console.ReadLine());
        if(a<0){
            Console.WriteLine("-1");
        }
        else if(a>32676){
            Console.WriteLine("-2");
        }
        else{
            SumOfNCubes obj = new SumOfNCubes();
            Console.Write(obj.Sum(a));
            }
        }
    }