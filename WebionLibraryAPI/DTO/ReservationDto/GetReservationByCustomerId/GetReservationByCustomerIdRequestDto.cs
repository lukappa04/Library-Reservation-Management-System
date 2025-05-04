using System.ComponentModel.DataAnnotations;

namespace WebionLibraryAPI.DTO.ReservationDto.GetReservationByCustomerId;

public sealed class GetReservationByCustomerIdRequestDto
{
    [Required]
    public int CustomerId { get; set; }
}