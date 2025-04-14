using WebionLibraryAPI.Data.Enum;
using WebionLibraryAPI.Data.Repository.Interfaces.BookRepoInterface;
using WebionLibraryAPI.Data.Repository.Interfaces.ReservationRepoInterface;
using WebionLibraryAPI.DTO.ReservationDto;
using WebionLibraryAPI.DTO.ReservationDto.CreateReservation;
using WebionLibraryAPI.DTO.ReservationDto.DeleteReservation;
using WebionLibraryAPI.DTO.ReservationDto.GetReservationByCustomerId;
using WebionLibraryAPI.Models.Reservations;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Service;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IBookRepository _bookRepository;
    public ReservationService(IReservationRepository reservationRepository, IBookRepository bookRepository)
    {
        _reservationRepository = reservationRepository;
        _bookRepository = bookRepository;
    }
    public async Task<ReservationResponse> AddReservation(CreateReservationRequestDto request)
    {
        var book = await _bookRepository.GetBookByIdAsync(request.BookId);
        if (book == null) throw new Exception("Libro non trovato.");

        if (book.Status != BooksStatusE.Available) throw new Exception("Il libro non è disponibile per la prenotazione.");

        ReservationM newReservation = new ReservationM
        {
            CustomerId = request.CustomerId,
            BookId = request.BookId,
            ReservationDate = DateTime.UtcNow,
            ExpirationDate = DateTime.UtcNow.AddDays(7) 
        };

        book.Status = BooksStatusE.Unavailable;
        await _reservationRepository.AddReservation(newReservation);
        return new ReservationResponse(newReservation);
    }

    public async Task<bool> DeleteReservation(DeleteReservationRequestDto request)
    {
        ReservationM? reservation = await _reservationRepository.GetReservationByCustomerId(request.ReservationId);
        if(reservation == null) return false;

        await _reservationRepository.DeleteReservation(reservation);
        return true;
    }

    public async Task<ReservationResponse> GetReservationById(GetReservationByCustomerIdRequestDto request)
    {
        var reservation = await _reservationRepository.GetReservationByCustomerId(request.CustomerId);
        return reservation is not null ? new ReservationResponse(reservation) : null;
    }
}