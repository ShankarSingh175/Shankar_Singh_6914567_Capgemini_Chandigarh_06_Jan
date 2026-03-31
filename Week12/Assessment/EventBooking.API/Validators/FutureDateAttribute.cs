using System.ComponentModel.DataAnnotations;

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        if (value is DateTime date && date > DateTime.Now)
            return ValidationResult.Success;

        return new ValidationResult("Date must be in future");
    }
}