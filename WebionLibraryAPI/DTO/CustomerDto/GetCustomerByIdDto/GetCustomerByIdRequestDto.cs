using System.ComponentModel.DataAnnotations;

namespace WebionLibraryAPI.DTO.CustomerDto.GetCustomerByIdDto;

public sealed class GetCustomerByIdRequestDto
{
    [Required]
    public int Id { get; set; }
}