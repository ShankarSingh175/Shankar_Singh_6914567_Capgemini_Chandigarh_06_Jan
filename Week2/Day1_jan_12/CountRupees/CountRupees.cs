class CountRupees{
    public int func(int a){
        int temp=a;
        int Count=0;
        while(temp>=500){
            temp-=500;
            Count++;
        }
        while(temp>=100){
            temp-=100;
            Count++;
        }
        while(temp>=50){
            temp-=50;
            Count++;
        }
        while(temp>=10){
            temp-=10;
            Count++;
        }
        while(temp>=1){
            temp-=1;
            Count++;
        }
        return Count;
    }
}