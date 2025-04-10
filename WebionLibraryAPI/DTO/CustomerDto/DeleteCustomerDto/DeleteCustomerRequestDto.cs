using System.ComponentModel.DataAnnotations;

namespace WebionLibraryAPI.DTO.CustomerDto.DeleteCustomerDto;

public sealed class DeleteCustomerRequestDto
{
    [Required]
    public int Id { get; set; }
}