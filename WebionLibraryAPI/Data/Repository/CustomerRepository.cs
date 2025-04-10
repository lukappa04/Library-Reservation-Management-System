using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebionLibraryAPI.Data.LibDbContext;
using WebionLibraryAPI.Data.Repository.Interfaces.CustomerRepoInterface;
using WebionLibraryAPI.Models.Customers;

namespace WebionLibraryAPI.Data.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly IMemoryCache _cache;
    private readonly LibraryDbContext _context;
    private const string CacheKey = "customer_cache_KEY";
    public CustomerRepository(LibraryDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }
    public async Task AddCustomerAsync(CustomerM customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        _cache.Remove(CacheKey);
    }

    public async Task DeleteCustomerAsync(CustomerM customer)
    {
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        _cache.Remove(CacheKey);
    }

    public async Task<List<CustomerM>> GetAllCustomerAsync()
    {
        if(_cache.TryGetValue(CacheKey, out List<CustomerM> customer))
        {
            return customer;
        }
        var customerDb = await _context.Customers.ToListAsync();
        _cache.Set(CacheKey, customerDb, TimeSpan.FromMinutes(10));
        return customerDb;
    }

    public async Task<CustomerM?> GetCustomerByIdAsync(int id)
    {
        var customer = await GetAllCustomerAsync();
        return customer.FirstOrDefault(c => c.Id == id);
    }

    public async Task<bool> isEmailExisting(string email)
    {
        var customerEmail = await GetAllCustomerAsync();
        return customerEmail.Any(ce => ce.Email == email);
    }

    public async Task UpdateCustomerAsync(int id, CustomerM customer)
    {
        var existingUser = await _context.Customers.FindAsync(id);
        if(existingUser is null) throw new KeyNotFoundException($"Customer with ID {id} not found");

        existingUser.FirstName = customer.FirstName;
        existingUser.LastName = customer.LastName;
        existingUser.Email = customer.Email;
        
        await _context.SaveChangesAsync();
        _cache.Remove(CacheKey);
    }
}