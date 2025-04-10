using WebionLibraryAPI.Models.Customers;

namespace WebionLibraryAPI.Data.Repository.Interfaces.CustomerRepoInterface;

public interface ICustomerRepository
{
    Task<List<CustomerM>> GetAllCustomerAsync();
    Task<CustomerM?> GetCustomerByIdAsync(int id);
    Task AddCustomerAsync(CustomerM customer);
    Task UpdateCustomerAsync(int id, CustomerM customer);
    Task DeleteCustomerAsync(CustomerM customer);
    Task<bool> isEmailExisting(string email);
}