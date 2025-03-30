using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebionLibraryAPI.Data.Enum;

namespace WebionLibraryAPI.Models.Books;
/// <summary>
/// classe che definisce le proprieta per la tabella relativa ai Libri (Book) della libreria
/// </summary>
public class BookM : IObjects
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Imposta la PrimaryKey AutoIncremental
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public BooksStatusE Status { get; set; }
}