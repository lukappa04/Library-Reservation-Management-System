using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebionLibraryAPI.Data.LibDbContext;
using WebionLibraryAPI.Data.Repository.Interfaces.ReservationRepoInterface;
using WebionLibraryAPI.Models.Reservations;

namespace WebionLibraryAPI.Data.Repository;

public class ReservationRepository : IReservationRepository
{
    private readonly LibraryDbContext _context;
    private readonly IMemoryCache _cache;
    private const string CacheKey = "customer_cache_KEY";
    public ReservationRepository(LibraryDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task AddReservation(ReservationM reservation)
    {
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();
        _cache.Remove(CacheKey);
    }

    public async Task DeleteReservation(ReservationM reservation)
    {
        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
        _cache.Remove(CacheKey);
    }

    public async Task<List<ReservationM?>> GetReservationByCustomerId(int id)
    {
        var reservation = await GetAllReservation();
        return reservation.Where(r => r.CustomerId == id).ToList();
    }

    public async Task<List<ReservationM>> GetAllReservation()
    {
        if(_cache.TryGetValue(CacheKey, out List<ReservationM>? reservations))
        {
            return reservations;
        }
        var reservationDb = await _context.Reservations.ToListAsync();
        _cache.Set(CacheKey, reservationDb, TimeSpan.FromMinutes(10));
        return reservationDb;
    }

    public async Task<ReservationM?> GetReservationById(int Id)
    {
        var reservation = await GetAllReservation();
        return reservation.FirstOrDefault(r => r.BookId == Id);
    }
}