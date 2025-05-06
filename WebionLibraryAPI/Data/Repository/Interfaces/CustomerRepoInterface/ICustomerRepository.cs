using WebionLibraryAPI.Models.Customers;

namespace WebionLibraryAPI.Data.Repository.Interfaces.CustomerRepoInterface;
/// <summary>
/// Interfaccia per la gestione del repository dei clienti.
/// Definisce le operazioni CRUD e di ricerca.
/// </summary>
public interface ICustomerRepository
{
    Task<List<CustomerM>>? GetAllCustomerAsync();
    Task<CustomerM?> GetCustomerByIdAsync(int id);
    Task AddCustomerAsync(CustomerM customer);
    Task UpdateCustomerAsync(int id, CustomerM customer);
    Task DeleteCustomerAsync(CustomerM customer);
    Task<bool> isEmailExisting(string email);
}