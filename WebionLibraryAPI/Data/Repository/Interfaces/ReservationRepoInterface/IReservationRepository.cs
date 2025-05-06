using Microsoft.EntityFrameworkCore.Storage;
using WebionLibraryAPI.Models.Reservations;

namespace WebionLibraryAPI.Data.Repository.Interfaces.ReservationRepoInterface;
/// <summary>
/// Interfaccia per la gestione del repository dei clienti.
/// Definisce le operazioni CRUD e di ricerca.
/// </summary>
public interface IReservationRepository
{
    Task<List<ReservationM>> GetAllReservation();
    Task<List<ReservationM?>> GetReservationByCustomerId (int id);
    Task<ReservationM?> GetReservationById (int Id);
    Task DeleteReservation (ReservationM reservation);
    Task AddReservation(ReservationM reservation);

}