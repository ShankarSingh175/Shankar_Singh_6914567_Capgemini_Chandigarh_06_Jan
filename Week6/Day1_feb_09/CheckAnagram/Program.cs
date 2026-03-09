class Program
{
    public static void Main(){
        int n= int.Parse(Console.ReadLine());
        string[] str = new string[n];
        for(int i=0;i<n;i++){
            str[i] = Console.ReadLine();
        }
        for(int i=0;i<n-1;i++){
            var input1 = str[i];
            var input2 = str[i+1];
            int count = 0;
            for(int j=0;j<input1.Length;j++){
                for(int k=0;k<input1.Length;k++){
                    if(input1[j] == input2[k]) count++;
                }
            }
            if(count!=input1.Length){
                Console.WriteLine("Not Anagram!");
                return;
            }
        }
        Console.WriteLine("ANagram!");
    }
}