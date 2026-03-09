class Program
{
    public static void Main(){
        string str = Console.ReadLine();
        string remove = Console.ReadLine();
        string insert = Console.ReadLine();
        int index = str.IndexOf(remove);
        str = str.Remove(index,remove.Length);
        str=str.Insert(index,insert);
        Console.WriteLine(str);
    }
}