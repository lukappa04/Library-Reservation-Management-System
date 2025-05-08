using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebionLibraryAPI.DataChecker.CustomerDataChecker;
/// <summary>
/// Classe dedicata al controllo della struttura dell'email inserita dall'utente
/// </summary>
public class EmailStructChecker : ValidationAttribute
{
    /// <summary>
    /// la constante che definisce la struttura predefinita che l'email deve avere per essere approvata
    /// </summary>
    private const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    /// <summary>
    /// Questo è il metodo di creazione del attributo per la validazione dell'email
    /// </summary>
    /// <param name="value">valore da controllare</param>
    /// <param name="validationContext"></param>
    /// <returns>Success se l'input viene approvato, errore in caso contrario</returns>
    /// <exception cref="Exception"></exception>
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string email)
        {
            if(!Regex.IsMatch(email, EmailPattern))
            {
                return new ValidationResult("Email structure is wrong");
            }
        }
        return ValidationResult.Success;
    }
}