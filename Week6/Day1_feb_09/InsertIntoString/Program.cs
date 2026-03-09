class Program{
    public static void Main(String[] args){
        string str = Console.ReadLine();
        Console.WriteLine("At which index do u want to insert: ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Write the character u want to insert: ");
        string b = Console.ReadLine();
        string output = "";
        for(int i=0;i<str.Length;i++){
            if (i == a)
            {
                output+=b;
            }
            output+=str[i];
        }
        Console.WriteLine("String becomes:" + output);
    }
}