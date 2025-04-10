using System.ComponentModel.DataAnnotations;
using WebionLibraryAPI.DataChecker.CustomerDataChecker;

namespace WebionLibraryAPI.DTO.CustomerDto.UpdateCustomerDto;

public sealed class UpdateCustomerRequestDto
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [EmailStructChecker]
    public string Email { get; set; } = string.Empty;
}