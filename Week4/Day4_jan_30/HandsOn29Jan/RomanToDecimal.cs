using System;
using System.Collections.Generic;

class UserProgramCode
{
    public static int convertRomanToDecimal(string input)
    {
        Dictionary<char, int> roman = new Dictionary<char, int>()
        {
            {'I',1},{'V',5},{'X',10},{'L',50},
            {'C',100},{'D',500},{'M',1000}
        };

        int total = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (!roman.ContainsKey(input[i]))
                return -1;

            int value = roman[input[i]];

            if (i + 1 < input.Length && roman[input[i + 1]] > value)
                total -= value;
            else
                total += value;
        }

        return total;
    }
    public static int GetCount(int size, string[] input1, char input2)
    {
        int count = 0;

        foreach (string str in input1)
        {
            foreach (char ch in str)
            {
                if (!char.IsLetter(ch))
                    return -2;
            }

            if (char.ToLower(str[0]) == char.ToLower(input2))
                count++;
        }

        if (count == 0)
            return -1;

        return count;
    }
}
