using System.ComponentModel.DataAnnotations;

namespace WebionLibraryAPI.DTO.ReservationDto.DeleteReservation;

public sealed class DeleteReservationRequestDto
{
    [Required]
    public int BookId { get; set; }
}