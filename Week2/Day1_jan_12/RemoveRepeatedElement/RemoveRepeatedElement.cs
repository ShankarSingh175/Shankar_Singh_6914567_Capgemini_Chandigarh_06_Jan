using System.Collections.Generic;
class RemoveRepeatedElement{
    public int[] func(int[] arr,int n){
        List<int> a = new List<int>();
        for(int i=0;i<n;i++){
            if(!a.Contains(arr[i])){
                a.Add(arr[i]);
            }
        }
        return a.ToArray();
    }
}