using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine(AddYearsToDate("12/03/2022", 2));     
        Console.WriteLine(AddYearsToDate("12-03-2022", 2));     
        Console.WriteLine(AddYearsToDate("12/03/2022", -1));  

        Console.WriteLine(CheckSubstringOrder("todayisc#exam", "is", "exam")); 

        Console.WriteLine(AddYearAndFindDay("15/08/2023"));     

        Console.WriteLine(CountTripleRepeats("abcdddefggg"));   
        Console.WriteLine(CountTripleRepeats("ertyyyrere"));    

        Console.WriteLine(RemoveDuplicateChars("hi this is my book"));

        Console.WriteLine(CheckVotingEligibility(20));          
        Console.WriteLine(CheckVotingEligibility(15));         

        Console.WriteLine(CheckTimeFormat("09:30 am"));        
        Console.WriteLine(CheckTimeFormat("13:30 pm"));       

        Console.WriteLine(CheckNumericArray(new string[] { "23", "24.5" }));
        Console.WriteLine(CheckNumericArray(new string[] { "23", "one" }));  

        Console.WriteLine(GetFileExtension("File.dat"));       

        Console.WriteLine(ValidatePassword("ashok_23"));       
        Console.WriteLine(ValidatePassword("1991_23"));       
    }

    static string AddYearsToDate(string date, int years)
    {
        if (years < 0) return "-2";

        if (!DateTime.TryParseExact(date, "dd/MM/yyyy",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None, out DateTime dt))
        {
            return "-1";
        }

        return dt.AddYears(years).ToString("dd/MM/yyyy");
    }

    static int CheckSubstringOrder(string input1, string input2, string input3)
    {
        int i2 = input1.IndexOf(input2);
        int i3 = input1.IndexOf(input3);

        if (i2 != -1 && i3 != -1 && i3 > i2)
            return 1;

        return -1;
    }

    static string AddYearAndFindDay(string date)
    {
        DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy",
            CultureInfo.InvariantCulture);

        return dt.AddYears(1).DayOfWeek.ToString();
    }

    static int CountTripleRepeats(string input)
    {
        return Regex.Matches(input, @"(.)\1{2,}").Count;
    }

    static string RemoveDuplicateChars(string input)
    {
        string result = "";
        foreach (char c in input)
        {
            if (!result.Contains(c))
                result += c;
        }
        return result;
    }

    static int CheckVotingEligibility(int age)
    {
        return age >= 18 ? 1 : -1;
    }

    static int CheckTimeFormat(string time)
    {
        string pattern = @"^(0[1-9]|1[0-2]):[0-5][0-9]\s(am|pm)$";
        return Regex.IsMatch(time, pattern, RegexOptions.IgnoreCase) ? 1 : -1;
    }

    static int CheckNumericArray(string[] arr)
    {
        foreach (string s in arr)
        {
            if (!double.TryParse(s, out _))
                return -1;
        }
        return 1;
    }

    static string GetFileExtension(string filename)
    {
        return filename.Contains(".")
            ? filename.Substring(filename.LastIndexOf('.') + 1)
            : "";
    }

    static int ValidatePassword(string password)
    {
        string pattern =
            @"^(?![\d\W])            # should not start with digit or spl char
              (?=.*[@#_])            # must contain @ # _
              (?=.*[A-Za-z])         # must contain letter
              (?=.*\d)               # must contain digit
              .{7,}                  # min length check (excluding last)
              [A-Za-z0-9]$            # should not end with spl char
             ";

        return Regex.IsMatch(password, pattern,
            RegexOptions.IgnorePatternWhitespace) ? 1 : -1;
    }
}
