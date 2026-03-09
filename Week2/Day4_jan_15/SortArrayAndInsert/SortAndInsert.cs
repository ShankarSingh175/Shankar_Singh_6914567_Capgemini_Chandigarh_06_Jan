class SortAndInsert{
    public void func(int[] arr,int n){
        List <int> ls= arr.ToList();
        int a = int.Parse(Console.ReadLine());
        ls.Add(a);
        ls.Sort();
        foreach (int i in ls)
        {
            Console.WriteLine(i);
        }
}}