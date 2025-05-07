using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.ReservationDto.CreateReservation;
using WebionLibraryAPI.Exceptions;
using WebionLibraryAPI.Service;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.ReservationController;
    /// <summary>
    /// Controller responsabile della creazione di una nuova prenotazione.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Reservation")]
    public class AddReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly ILogger<ReservationService> _logger;
        public AddReservationController(IReservationService reservationService,  ILogger<ReservationService> logger)
        {
            _reservationService = reservationService;
            _logger = logger;
        }
        /// <summary>
        /// Crea una nuova prenotazione.
        /// </summary>
        /// <param name="request">Dati della prenotazione da creare</param>
        /// <returns>La prenotazione creata.</returns>
        [HttpPost]
        public async Task<IActionResult> AddReservation(CreateReservationRequestDto request)
        {
            try	{
            var reservation = await _reservationService.AddReservation(request);
            _logger.LogInformation($"Reservation Date: {reservation.ReservationDate}");

            return reservation is not null ? Ok(reservation) : NotFound("Libro non trovato");
            }catch(DataNotFoundExc){
                return BadRequest("Libro non disponibile per la prenotazione");
            }
            catch(DataNotAvailableExc)
            {
                return BadRequest($"Cliente non disponibile");
            }
        }
    }

