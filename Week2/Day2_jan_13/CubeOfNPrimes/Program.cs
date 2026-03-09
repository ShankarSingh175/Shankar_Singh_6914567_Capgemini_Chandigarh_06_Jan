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
            CubeOfNPrimes obj = new CubeOfNPrimes();
            Console.Write(obj.Sum(a));
            }
        }
    }