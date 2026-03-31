namespace SecureAccountDetails.DTOs;

public class AccountDetailsDto
{
    public required string AccountHolderName { get; set; }
public required string MaskedAccountNumber { get; set; } // This will hold masked or full number based on role
    public decimal? Balance { get; set; } // Nullable, only populated for Admin
}