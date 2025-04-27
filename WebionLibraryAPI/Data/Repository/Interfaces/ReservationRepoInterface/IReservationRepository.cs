using Microsoft.EntityFrameworkCore.Storage;
using WebionLibraryAPI.Models.Reservations;

namespace WebionLibraryAPI.Data.Repository.Interfaces.ReservationRepoInterface;

public interface IReservationRepository
{
    Task<List<ReservationM>> GetAllReservation();
    Task<List<ReservationM?>> GetReservationByCustomerId (int id);
    Task<ReservationM?> GetReservationById (int Id);
    Task DeleteReservation (ReservationM reservation);
    Task AddReservation(ReservationM reservation);

}