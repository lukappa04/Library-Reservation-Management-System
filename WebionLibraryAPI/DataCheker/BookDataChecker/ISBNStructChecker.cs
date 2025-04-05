using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using WebionLibraryAPI.Models.Books;

namespace WebionLibraryAPI.DataChecker.BookDataChecker;
/// <summary>
/// Classe dedicata al controllo della struttura el ISBN dei libri. 
/// </summary>
public class ISBNStructChecker : ValidationAttribute
{
    /// <summary>
    /// Le due constanti definiscono la struttura predefinita che l'ISBN deve avere
    /// </summary>
    private const string _isbnPattern13 = @"^(?:\d{13}|\d{3}-\d{1,5}-\d{1,7}-\d{1,7}-[\dXx])$";
    private const string _isbnPattern10 = @"^(?:\d{9}[\dXx]|\d{1,5}-\d{1,7}-\d{1,7}-[\dXx])$";
    /// <summary>
    /// Questo è il metodo per la creazione del attributo, dove viene effettuata la verifica
    /// </summary>
    /// <param name="value">valore da controllare</param>
    /// <param name="validationContext"></param>
    /// <returns>Success se i controlli vengono passati, se lancia un errore in caso contrario</returns>
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string isbn)
        {
            if (!Regex.IsMatch(isbn, _isbnPattern13) && !Regex.IsMatch(isbn, _isbnPattern10))
            {
                return new ValidationResult("L'ISBN deve essere lungo 10 o 13 caratteri.");
            }
        }
        return ValidationResult.Success;
    }
}