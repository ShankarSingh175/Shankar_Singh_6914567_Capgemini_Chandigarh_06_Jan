public class UserProgramCode
{
    public static int getDonation(string[] input1, int input2)
    {
        HashSet<string> uniqueSet = new HashSet<string>();
        foreach (string s in input1)
        {
            if (!uniqueSet.Add(s))
            {
                return -1;
            }
        }

        int totalDonation = 0;

        foreach (string s in input1)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                {
                    return -2;
                }
            }

            int locationCode = int.Parse(s.Substring(3, 3));
            int donation = int.Parse(s.Substring(6, 3));

            if (locationCode == input2)
            {
                totalDonation += donation;
            }
        }

        return totalDonation;
    }
}
