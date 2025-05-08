using WebionLibraryAPI.Data.Repository.Interfaces.BookRepoInterface;
using WebionLibraryAPI.Data.Repository.Interfaces.CustomerRepoInterface;
using WebionLibraryAPI.DTO.CustomerDto;
using WebionLibraryAPI.DTO.CustomerDto.AddCustomerDto;
using WebionLibraryAPI.DTO.CustomerDto.DeleteCustomerDto;
using WebionLibraryAPI.DTO.CustomerDto.GetCustomerByIdDto;
using WebionLibraryAPI.DTO.CustomerDto.UpdateCustomerDto;
using WebionLibraryAPI.Exceptions;
using WebionLibraryAPI.Models.Customers;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Service;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<CustomerService> _logger;
    public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> logger)
    {
        _customerRepository = customerRepository;
        _logger = logger;
    }
    public async Task<CustomerResponseDto> AddCustomerAsync(AddCustomerRequestDto request)
    {
        CustomerM newCustomer = new CustomerM
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            RegistrationDate = DateTime.UtcNow,
            LastModifiedAt = DateTime.UtcNow
        };
        if(await _customerRepository.isEmailExisting(request.Email))
        { 
            _logger.LogError("Log: Email già esistente");  
            throw new DataAlreadyExistExc();
        }

        await _customerRepository.AddCustomerAsync(newCustomer);
        return new CustomerResponseDto(newCustomer);
    }

    public async Task<bool> DeleteCustomerAsync(DeleteCustomerRequestDto request)
    {
        CustomerM? customer = await _customerRepository.GetCustomerByIdAsync(request.Id);
        if(customer == null)
        {
            _logger.LogWarning("Log: Customer is null");
            return false;
        }

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

    public async Task<CustomerResponseDto?> UpdateCustomerAsync(int id, UpdateCustomerRequestDto request)
    {
        CustomerM? updateCustomer = await _customerRepository.GetCustomerByIdAsync(id);
        if(updateCustomer is null)
        { 
            _logger.LogWarning("Log: Data is null");
            return null;
        }
        var allCustomers = await _customerRepository.GetAllCustomerAsync();
        bool emailExists = allCustomers
        .Any(c => c.Email == request.Email && c.Id != id);

        if (emailExists)
        {
            _logger.LogError("Log: Questa email è già associata ad un altro cliente");
            throw new DataAlreadyExistExc();
        }

        updateCustomer.FirstName = request.FirstName;
        updateCustomer.LastName = request.LastName;
        updateCustomer.Email = request.Email;
        updateCustomer.LastModifiedAt = DateTime.UtcNow;

        

        await _customerRepository.UpdateCustomerAsync(id, updateCustomer);
        return new CustomerResponseDto(updateCustomer);
    }
}