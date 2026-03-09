class Program
{
    public static void Main(){
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for(int i=0;i<n;i++){
            arr[i] = int.Parse(Console.ReadLine());
        }
        HashSet<int> a= new HashSet<int> ();
        foreach (int item in arr)
        {
            a.Add(item);
        }
        int[] output = a.ToArray();
        foreach(int i in output){
            Console.Write(i);
        }
    }
}