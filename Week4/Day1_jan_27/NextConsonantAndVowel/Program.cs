class UserProgramCode{
    public static string Answer(string str){
        string ans ="";
        foreach( char i in str){
            if(checkVowel(i)){
                ans+=getNextConsonant(i);
            }
            else{
                ans+=getNextVowel(i);
            }
        }
        return ans;
    }
    public static bool checkVowel(char i){
        if(Char.ToLower(i) == 'a' || Char.ToLower(i) =='e' || Char.ToLower(i) == 'i' || Char.ToLower(i) == 'o' || Char.ToLower(i) == 'u'){
            return true;
        }
        else{
            return false;
        }
    }
    public static char getNextConsonant(char i){
        return ++i;
    }
    public static char getNextVowel(char i){
        if(i>'a' && i<'e') return 'e';
        else if(i>'e' && i<'i') return 'i';
        else if(i>'i' && i<'o') return 'o';
        else if(i>'o' && i<'u') return 'u';
        else if(i>'u' && i<='z') return 'a';
        else if(i>'A' && i<'E') return 'E';
        else if(i>'E' && i<'I') return 'I';
        else if(i>'I' && i<'O') return 'O';
        else if(i>'O' && i<'U') return 'U';
        else if(i>'U' && i<='Z') return 'A';
        else return '0';
    }
}

class Program{
    public static void Main(){
        string str = Console.ReadLine();
        Console.Write(UserProgramCode.Answer(str));
    }
}