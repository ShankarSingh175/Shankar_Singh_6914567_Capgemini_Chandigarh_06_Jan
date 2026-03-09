class Program
{
    public static void Main(){
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for(int i=0;i<n;i++){
            arr[i] = int.Parse(Console.ReadLine());
        }
        Dictionary<int,int> freq = new Dictionary<int,int>();
        for(int i = 0;i<n;i++){
            int count =0;
            for(int j=0;j<n;j++){
                if(arr[i]==arr[j]){
                    count++;
                }
            }
            freq[arr[i]] = count;
        }
        foreach (var p in freq)
        {
            Console.WriteLine(p.Key + " " + p.Value);
        }
    }
}