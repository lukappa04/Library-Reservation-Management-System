using WebionLibraryAPI.DTO.CustomerDto;
using WebionLibraryAPI.DTO.CustomerDto.AddCustomerDto;
using WebionLibraryAPI.DTO.CustomerDto.DeleteCustomerDto;
using WebionLibraryAPI.DTO.CustomerDto.GetCustomerByIdDto;
using WebionLibraryAPI.DTO.CustomerDto.UpdateCustomerDto;
using WebionLibraryAPI.Models.Customers;

namespace WebionLibraryAPI.Service.Interfaces;
/// <summary>
/// Interfaccia per la gestione del repository dei clienti.
/// Definisce le operazioni CRUD e di ricerca.
/// </summary>
public interface ICustomerService
{
    Task<IEnumerable<CustomerResponseDto>> GetAllCustomerAsync();
    Task<CustomerResponseDto> GetCustomerByIdAsync(GetCustomerByIdRequestDto request);
    Task<CustomerResponseDto?> UpdateCustomerAsync(int id, UpdateCustomerRequestDto request);
    Task<bool> DeleteCustomerAsync(DeleteCustomerRequestDto request);
    Task<CustomerResponseDto> AddCustomerAsync(AddCustomerRequestDto request);
}