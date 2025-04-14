using WebionLibraryAPI.DTO.ReservationDto;
using WebionLibraryAPI.DTO.ReservationDto.CreateReservation;
using WebionLibraryAPI.DTO.ReservationDto.DeleteReservation;
using WebionLibraryAPI.DTO.ReservationDto.GetReservationByCustomerId;

namespace WebionLibraryAPI.Service.Interfaces;

public interface IReservationService
{
    Task<ReservationResponse> GetReservationById (GetReservationByCustomerIdRequestDto request);
    Task<ReservationResponse> AddReservation (CreateReservationRequestDto request);
    Task<bool> DeleteReservation (DeleteReservationRequestDto request);
}