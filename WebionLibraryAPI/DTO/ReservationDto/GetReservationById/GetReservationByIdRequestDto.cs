using System.ComponentModel.DataAnnotations;

namespace WebionLibraryAPI.DTO.ReservationDto.GetReservationById;

public sealed class GetReservationByIdRequestDto 
{
    [Required]
    public int Id { get; set; }
}