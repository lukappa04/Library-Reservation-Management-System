using WebionLibraryAPI.DTO.ReservationDto;
using WebionLibraryAPI.DTO.ReservationDto.CreateReservation;
using WebionLibraryAPI.DTO.ReservationDto.DeleteReservation;
using WebionLibraryAPI.DTO.ReservationDto.GetReservationByCustomerId;
using WebionLibraryAPI.DTO.ReservationDto.GetReservationById;

namespace WebionLibraryAPI.Service.Interfaces;
/// <summary>
/// Interfaccia per la gestione del repository delle prenotazioni.
/// Definisce le operazioni CRUD e di ricerca.
/// </summary>
public interface IReservationService
{
    Task<List<ReservationResponse>> GetReservationByCustomerId (GetReservationByCustomerIdRequestDto request);
    Task<ReservationResponse> AddReservation (CreateReservationRequestDto request);
    Task CheckExpiredReservationsAsync();
    Task<ReservationResponse> GetReservationById (GetReservationByIdRequestDto  request);
    Task<bool> DeleteReservation (DeleteReservationRequestDto request);
}