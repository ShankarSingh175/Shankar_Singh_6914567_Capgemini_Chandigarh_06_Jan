class SumOfSquareOddDigits{
    public int func(int a){
        int num=a;
        int sum=0;
        while(num>0){
            int temp = num%10;
            if(temp%2!=0 && temp!=1){
                sum += temp*temp;
            }
            num/=10;
        }
        return sum;
    }
}