using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebionLibraryAPI.Models.Books;
using WebionLibraryAPI.Models.Customers;

namespace WebionLibraryAPI.Models.Reservations;

public class ReservationM : IObjects
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //imposta la PK AutoIncremental
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public CustomerM Customer { get; set; }
    
    public int BookId { get; set; }
    public BookM Book { get; set; }

    public DateTime ReservationDate { get; set; }
    public DateTime ExpirationDate { get; set; }
}