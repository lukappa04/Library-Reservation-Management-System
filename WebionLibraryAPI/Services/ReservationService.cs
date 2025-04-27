using Npgsql.Internal;
using WebionLibraryAPI.Data.Enum;
using WebionLibraryAPI.Data.Repository.Interfaces.BookRepoInterface;
using WebionLibraryAPI.Data.Repository.Interfaces.ReservationRepoInterface;
using WebionLibraryAPI.DTO.ReservationDto;
using WebionLibraryAPI.DTO.ReservationDto.CreateReservation;
using WebionLibraryAPI.DTO.ReservationDto.DeleteReservation;
using WebionLibraryAPI.DTO.ReservationDto.GetReservationByCustomerId;
using WebionLibraryAPI.DTO.ReservationDto.GetReservationById;
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
        await CheckExpiredReservationsAsync();
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
        await _bookRepository.UpdateBookAsync(book.Id, book);
        await _reservationRepository.AddReservation(newReservation);
        return new ReservationResponse(newReservation);
    }

    public async Task CheckExpiredReservationsAsync()
    {
        var reservations = await _reservationRepository.GetAllReservation();

        foreach (var reservation in reservations)
        {
            if (reservation.ExpirationDate < DateTime.UtcNow)
            {
                var book = await _bookRepository.GetBookByIdAsync(reservation.BookId);

                if (book != null && book.Status == BooksStatusE.Unavailable)
                {
                    book.Status = BooksStatusE.Available;
                    await _bookRepository.UpdateBookAsync(book.Id, book);
                }

                await _reservationRepository.DeleteReservation(reservation);
            }
        }
    }

    public async Task<bool> DeleteReservation(DeleteReservationRequestDto request)
    {
        ReservationM? reservation = await _reservationRepository.GetReservationById(request.BookId);

        var book = await _bookRepository.GetBookByIdAsync(reservation.BookId);

        if(reservation == null) return false;

        book.Status = BooksStatusE.Available;

        await _bookRepository.UpdateBookAsync(book.Id, book);
        await _reservationRepository.DeleteReservation(reservation);
        return true;
    }

    public async Task<List<ReservationResponse>> GetReservationByCustomerId(GetReservationByCustomerIdRequestDto request)
    {
        //TODO: controllare perchè non accetta l'Id, il problema potrebbe essere anche a livello di controller. 
        var reservations = await _reservationRepository.GetReservationByCustomerId(request.CustomerId);

        if (reservations == null || !reservations.Any())
            return new List<ReservationResponse>();

        return reservations.Select(r => new ReservationResponse(r)).ToList();
    }

    public async Task<ReservationResponse> GetReservationById(GetReservationByIdRequestDto  request)
    {
        var reservation = await _reservationRepository.GetReservationById(request.Id);
        return reservation is not null ? new ReservationResponse(reservation) : null;
    }
}