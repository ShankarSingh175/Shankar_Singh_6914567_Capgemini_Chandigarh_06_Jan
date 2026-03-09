class UserProgramCode{
    public static int ValidateTime(String str){
        int hr = int.Parse(str.Substring(0,2));
        int min = int.Parse(str.Substring(3,2));
        Char a = str[2];
        String b = str.Substring(6,2);
         if (hr < 1 || hr > 12 ||
            min < 0 || min > 59 ||
            a != ':' ||
            (b != "am" && b != "pm"))
        {
            return -1;
        }

        return 1;
    }
}


class Program{
    public static void Main(String[] args){
        String str = Console.ReadLine();
        UserProgramCode obj = new UserProgramCode();
        int a = UserProgramCode.ValidateTime(str);
        if(a==1){
            Console.Write("Valid Time Format");
        }
        else{
            Console.Write("Invalid Time Format");
        }
    }
}