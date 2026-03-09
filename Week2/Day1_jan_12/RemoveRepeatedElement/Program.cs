// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
    

class Program{
public static void Main(){
    int n = int.Parse(Console.ReadLine());
    int[] arr = new int[n];
    for(int i=0;i<n;i++){
        arr[i]=int.Parse(Console.ReadLine());
    }
    for(int i=0;i<n;i++){
        if(arr[i]<0){
            Console.Write("-1");
            return ;
        }
    }
    RemoveRepeatedElement obj = new RemoveRepeatedElement();
    int[] output = obj.func(arr, n);
    foreach (int i in output)
    {
        Console.Write(i);
    }
}}