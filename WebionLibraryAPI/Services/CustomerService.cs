using WebionLibraryAPI.Data.Repository.Interfaces.BookRepoInterface;
using WebionLibraryAPI.Data.Repository.Interfaces.CustomerRepoInterface;
using WebionLibraryAPI.DTO.CustomerDto;
using WebionLibraryAPI.DTO.CustomerDto.AddCustomerDto;
using WebionLibraryAPI.DTO.CustomerDto.DeleteCustomerDto;
using WebionLibraryAPI.DTO.CustomerDto.GetCustomerByIdDto;
using WebionLibraryAPI.DTO.CustomerDto.UpdateCustomerDto;
using WebionLibraryAPI.Models.Customers;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Service;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public async Task<CustomerResponseDto> AddCustomerAsync(AddCustomerRequestDto request)
    {
        CustomerM newCustomer = new CustomerM
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            RegistrationDate = request.RegistrationDate
        };
        if(await _customerRepository.isEmailExisting(request.Email)) throw new Exception("Email già esistente");

        await _customerRepository.AddCustomerAsync(newCustomer);
        return new CustomerResponseDto(newCustomer);
    }

    public async Task<bool> DeleteCustomerAsync(DeleteCustomerRequestDto request)
    {
        CustomerM? customer = await _customerRepository.GetCustomerByIdAsync(request.Id);
        if(customer == null) return false;

        await _customerRepository.DeleteCustomerAsync(customer);
        return true;
    }

    public async Task<IEnumerable<CustomerResponseDto>> GetAllCustomerAsync()
    {
        var customers = await _customerRepository.GetAllCustomerAsync();
        return customers.Select(customer => new CustomerResponseDto(customer));
    }

    public async Task<CustomerResponseDto> GetCustomerByIdAsync(GetCustomerByIdRequestDto request)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(request.Id);
        return customer is not null ? new CustomerResponseDto(customer) : null;
    }

    public async Task<CustomerResponseDto> UpdateCustomerAsync(int id, UpdateCustomerRequestDto request)
    {
        CustomerM updateCustomer = await _customerRepository.GetCustomerByIdAsync(id);
        if(updateCustomer is null) throw new KeyNotFoundException("Cliente non trovato");

        updateCustomer.FirstName = request.FirstName;
        updateCustomer.LastName = request.LastName;
        updateCustomer.Email = request.Email;

        await _customerRepository.UpdateCustomerAsync(id, updateCustomer);
        return new CustomerResponseDto(updateCustomer);
    }
}