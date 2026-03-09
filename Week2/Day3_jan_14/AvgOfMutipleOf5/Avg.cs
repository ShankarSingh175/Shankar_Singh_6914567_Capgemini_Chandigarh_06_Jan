class Avg{
    public int func(int a){
        int sum=0;
        int count=0;
        for(int i=1;i<=a;i++){
            if(i%5==0){
                sum+=i;
                count++;
            }
        }
        return (sum/count);
    }
}