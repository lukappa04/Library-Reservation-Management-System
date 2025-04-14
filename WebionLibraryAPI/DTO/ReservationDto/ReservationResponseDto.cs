using WebionLibraryAPI.Models.Reservations;

namespace WebionLibraryAPI.DTO.ReservationDto;

public sealed class ReservationResponse 
{
    public int CustomerId { get; set; }
    public int BookId { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public ReservationResponse(ReservationM reservation)      
    {
        CustomerId = reservation.CustomerId;
        BookId = reservation.BookId;
        ReservationDate = reservation.ReservationDate;
        ExpirationDate = reservation.ExpirationDate;
    }
}