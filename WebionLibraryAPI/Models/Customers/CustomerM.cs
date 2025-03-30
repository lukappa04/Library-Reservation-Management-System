using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebionLibraryAPI.Models.Customers;
/// <summary>
/// classe che definisce le proprieta per la tabella relativa ai Clienti (Customer) della libreria
/// </summary>
public class CustomerM : IObjects
{
    //l'attributo key fa capire ad EF che l'id è la PK della nostra tabella ed in automatico lo imposta come AI (Auto Incremental)
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //imposta la PK AutoIncremental
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    //ho scelto di non inserire l'attributo per rendere l'email unique in questo punto ma di inserire il controllo dentro il dbContext.
    public string Email { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
}