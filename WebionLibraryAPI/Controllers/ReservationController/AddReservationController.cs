using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.ReservationDto.CreateReservation;
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
        public AddReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        /// <summary>
        /// Crea una nuova prenotazione.
        /// </summary>
        /// <param name="request">Dati della prenotazione da creare</param>
        /// <returns>La prenotazione creata.</returns>
        [HttpPost]
        public async Task<IActionResult> AddReservation(CreateReservationRequestDto request)
        {
            var reservation = await _reservationService.AddReservation(request);
            Console.WriteLine($"Reservation Date: {reservation.ReservationDate}");

            return Ok(reservation);
        }
    }

