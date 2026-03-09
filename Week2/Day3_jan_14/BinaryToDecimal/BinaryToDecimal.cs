class BinaryToDecimal{
    public int func(int a){
        string str = a.ToString();
        foreach (char i in str)
        {
            if(i!='0' && i!='1'){
                return -1;
            }
        }
        if(str.Length>5){
            return -2;
        }
        int decimalVar=0;
        int baseVar = 1;
        for(int i= str.Length-1;i>=0;i--){
            if(str[i]=='1'){
                decimalVar+=baseVar;
            }
            baseVar*=2;
        }
        return decimalVar;
    }
}