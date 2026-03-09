class Program
{
    public static void Main(){
    string str = Console.ReadLine();
    Stack<char> st = new Stack<char>();
    int count =0;
    for(int i = str.Length-1;i>=0 ; i--)
    {
        if(st.Count()!=0 && st.Peek()==str[i]){
            st.Pop();
            count++;
        }
        else{
            st.Push(str[i]);
        }
    }
    Console.WriteLine(count);
    foreach (char item in st)
    {
        Console.Write(item);
    }
    }
}