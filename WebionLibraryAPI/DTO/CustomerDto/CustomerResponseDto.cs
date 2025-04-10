using Microsoft.AspNetCore.Localization;
using WebionLibraryAPI.Models.Customers;

namespace WebionLibraryAPI.DTO.CustomerDto;

public sealed class CustomerResponseDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
    public CustomerResponseDto(CustomerM customer)
    {
        Id = customer.Id;
        FirstName = customer.FirstName;
        LastName = customer.LastName;
        Email = customer.Email;
        RegistrationDate = customer.RegistrationDate;
    }
}