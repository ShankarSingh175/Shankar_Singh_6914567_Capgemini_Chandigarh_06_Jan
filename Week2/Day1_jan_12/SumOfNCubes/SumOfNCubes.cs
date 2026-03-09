class SumOfNCubes{
    public bool func(int a){
        for(int i=2;i*i<=a;i++){
            if(a%i==0){
                return false;
            }
        }
        return true;
    }
    public long Sum(int a){
         long sum = 0;

        for (int i = 2; i <= a; i++)
        {
            if (func(i))
            {
                sum += (long)i * i * i; 
            }
        }

        return sum;
    }
    }