namespace SecureAccountDetails.Models;

public class Accounts
{
    public int Id { get; set; }
    public string AccountHolderName { get; set; }
    public string AccountNumber { get; set; } // full number
    public decimal Balance { get; set; }
    public string UserId { get; set; }

    public string MaskedAccountNumber
    {
        get
        {
            if (string.IsNullOrEmpty(AccountNumber) || AccountNumber.Length < 4)
                return "****";
            return "****" + AccountNumber[^4..]; // last 4 digits
        }
    }
}