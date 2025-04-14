using WebionLibraryAPI.Models.Books;
using WebionLibraryAPI.Models.Customers;
using WebionLibraryAPI.Models.Reservations;

namespace WebionLibraryAPI.DTO.ReservationDto.CreateReservation;

public sealed class CreateReservationRequestDto
{
    public int CustomerId { get; set; }
    public int BookId { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime ExpirationDate { get; set; }
}