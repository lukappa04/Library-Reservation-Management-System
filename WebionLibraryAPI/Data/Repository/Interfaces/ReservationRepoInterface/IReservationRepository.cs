using WebionLibraryAPI.Models.Reservations;

namespace WebionLibraryAPI.Data.Repository.Interfaces.ReservationRepoInterface;

public interface IReservationRepository
{
    Task<List<ReservationM>> GetAllReservation();
    Task<ReservationM?> GetReservationByCustomerId (int id);
    Task DeleteReservation (ReservationM reservation);
    Task AddReservation(ReservationM reservation);

}