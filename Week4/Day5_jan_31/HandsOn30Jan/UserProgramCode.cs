class UserProgramCode {

    public static int sumOfDigits(string[] arr) {
        int sum = 0;

        foreach(string str in arr) {
            foreach(char ch in str) {
                if(char.IsDigit(ch)) {
                    sum += int.Parse(ch.ToString());
                }
            }
        }

        return sum;
    }

    public static string[] getEmployee(string[] input1, string input2) {
        if (string.IsNullOrWhiteSpace(input2))
            return new string[] { "Invalid Input" };

        foreach (string s in input1)
        {
            if (!s.All(char.IsLetter))
                return new string[] { "Invalid Input" };
        }

        if (!input2.Replace(" ", "").All(char.IsLetter))
            return new string[] { "Invalid Input" };

        string targetDesignation = input2.Trim().ToLower();

        List<string> employees = new List<string>();
        HashSet<string> allDesignations = new HashSet<string>();

        for (int i = 0; i < input1.Length - 1; i += 2)
        {
            string employeeName = input1[i];
            string designation = input1[i + 1].ToLower();

            allDesignations.Add(designation);

            if (designation.Equals(targetDesignation))
            {
                employees.Add(employeeName);
            }
        }

        if (employees.Count == 0)
        {
            return new string[] { $"No employee for {input2} designation" };
        }

        if (allDesignations.Count == 1 && allDesignations.Contains(targetDesignation))
        {
            return new string[] { $"All employees belong to same {input2} designation" };
        }

        return employees.ToArray();
    }

    public static string replaceString(string input1, int input2, char input3)
    {
        foreach (char c in input1)
        {
            if (!(char.IsLetter(c) || c == ' '))
                return "-1";
        }

        if (input2 <= 0)
            return "-2";

        if (char.IsLetterOrDigit(input3))
            return "-3";

        string[] words = input1.Split(' ');

        if (input2 > words.Length)
            return input1.ToLower();

        int index = input2 - 1;
        words[index] = new string(input3, words[index].Length);

        return string.Join(" ", words).ToLower();
    }

    public static string formString(string[] input1, int input2)
    {
        foreach (string str in input1)
        {
            foreach (char c in str)
            {
                if (!char.IsLetter(c))
                    return "-1";
            }
        }

        StringBuilder result = new StringBuilder();
        int index = input2 - 1;

        foreach (string str in input1)
        {
            if (index < str.Length)
                result.Append(str[index]);
            else
                result.Append('$');
        }

        return result.ToString();
    }



}