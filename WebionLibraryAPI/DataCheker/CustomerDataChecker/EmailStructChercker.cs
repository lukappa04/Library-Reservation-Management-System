using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebionLibraryAPI.DataChecker.CustomerDataChecker;

public class EmailStructChecker : ValidationAttribute
{
    private const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string email)
        {
            if(!Regex.IsMatch(email, EmailPattern))
            {
                throw new Exception("Email structure is wrong");
            }
        }
        return ValidationResult.Success;
    }
}