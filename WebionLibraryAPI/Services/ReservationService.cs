using Microsoft.AspNetCore.Http.HttpResults;
using Npgsql.Internal;
using WebionLibraryAPI.Data.Enum;
using WebionLibraryAPI.Data.Repository.Interfaces.BookRepoInterface;
using WebionLibraryAPI.Data.Repository.Interfaces.CustomerRepoInterface;
using WebionLibraryAPI.Data.Repository.Interfaces.ReservationRepoInterface;
using WebionLibraryAPI.DTO.ReservationDto;
using WebionLibraryAPI.DTO.ReservationDto.CreateReservation;
using WebionLibraryAPI.DTO.ReservationDto.DeleteReservation;
using WebionLibraryAPI.DTO.ReservationDto.GetReservationByCustomerId;
using WebionLibraryAPI.DTO.ReservationDto.GetReservationById;
using WebionLibraryAPI.Exceptions;
using WebionLibraryAPI.Models.Reservations;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Service;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IBookRepository _bookRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ILogger<ReservationService> _logger;
    public ReservationService(IReservationRepository reservationRepository, IBookRepository bookRepository, ICustomerRepository customerRepository, ILogger<ReservationService> logger)
    {
        _reservationRepository = reservationRepository;
        _bookRepository = bookRepository;
        _customerRepository = customerRepository;
        _logger = logger;
    }
    /// <summary>
    /// Metodo per la creazione di una prenotazione
    /// </summary>
    /// <param name="request">dati necessari per effettuare la richiesta: CustomerId, BookId, StartDate, ExpireDate</param>
    /// <returns>Una DTO response.</returns>
    /// <exception cref="Exception">Effettua un controllo sullo stato del libro, se disponibile procede, altrimente lancia un eccezione</exception>
    public async Task<ReservationResponse> AddReservation(CreateReservationRequestDto request)
    {
        await CheckExpiredReservationsAsync();
        var book = await _bookRepository.GetBookByIdAsync(request.BookId);
        if (book == null)
        {
            _logger.LogWarning("Log: Libro non trovato");
            throw new DataNotFoundExc();
        }
        var customer = await _customerRepository.GetCustomerByIdAsync(request.CustomerId);
        if(customer == null) throw new DataNotAvailableExc();

        if (book.Status != BooksStatusE.Available)
        {
            _logger.LogError("Log: Libro non disponibile per la prenotazione");
            throw new DataNotFoundExc();
        }

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

    /// <summary>
    /// metodo per controllare gli stati delle prenotazioni
    /// Cosa fa: itera su tutta la lista delle prenotazioni e confronta a singola prenotazione la data di oggi con la data salvata sotto la colonna di fine prenotazione "ExpiredDate"
    /// se la ExpiredDate è minore della data di oggi allora imposta lo stato del libro disponibile e procede ad eliminare la prenotazione.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Metodo per la cancellazione di una prenotazione
    /// </summary>
    /// <param name="request">L'id del libro da annullare</param>
    /// <returns>boolean return: true se è avunta con successo, false se ci sono state delle eccezioni.</returns>
    public async Task<bool> DeleteReservation(DeleteReservationRequestDto request)
    {
        ReservationM? reservation = await _reservationRepository.GetReservationById(request.BookId);

        if(reservation == null)
        {
            _logger.LogWarning("Log: Prenotazione non trovata");
            return false;
        }

        var book = await _bookRepository.GetBookByIdAsync(reservation.BookId);

        book.Status = BooksStatusE.Available;

        await _bookRepository.UpdateBookAsync(book.Id, book);
        await _reservationRepository.DeleteReservation(reservation);
        return true;
    }

    /// <summary>
    /// Metodo per ottenere tutte le prenotazioni di un singolo cliente
    /// </summary>
    /// <param name="request">Id del cliente</param>
    /// <returns>Una lista di prenotazioni</returns>
    public async Task<List<ReservationResponse>> GetReservationByCustomerId(GetReservationByCustomerIdRequestDto request)
    {
        var reservations = await _reservationRepository.GetReservationByCustomerId(request.CustomerId);

        if (reservations == null || !reservations.Any())
            return new List<ReservationResponse>();

        return reservations.Select(r => new ReservationResponse(r)).ToList();
    }
    /// <summary>
    /// Ottenere una prenotazione
    /// </summary>
    /// <param name="request">L'id del libro</param>
    /// <returns>la prenotazione</returns>
    public async Task<ReservationResponse> GetReservationById(GetReservationByIdRequestDto  request)
    {
        var reservation = await _reservationRepository.GetReservationById(request.Id);
        return reservation is not null ? new ReservationResponse(reservation) : null;
    }
}