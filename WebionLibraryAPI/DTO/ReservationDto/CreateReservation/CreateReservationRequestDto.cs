using System.ComponentModel.DataAnnotations;
using WebionLibraryAPI.Models.Books;
using WebionLibraryAPI.Models.Customers;
using WebionLibraryAPI.Models.Reservations;

namespace WebionLibraryAPI.DTO.ReservationDto.CreateReservation;

public sealed class CreateReservationRequestDto
{
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public int BookId { get; set; }
}