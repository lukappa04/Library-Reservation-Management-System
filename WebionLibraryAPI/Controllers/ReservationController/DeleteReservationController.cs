using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.ReservationDto.DeleteReservation;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.ReservationController;
    /// <summary>
    /// Controller responsabile dell'eliminazione di una prenotazione.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Reservation")]
    public class DeleteReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public DeleteReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        /// <summary>
        /// Elimina una prenotazione in base all'ID del libro.
        /// </summary>
        /// <param name="id">ID del libro per cui annullare la prenotazione</param>
        /// <returns>Nessun contenuto se eliminato con successo, altrimenti NotFound.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var request = new DeleteReservationRequestDto {BookId = id};
            var reservation = await _reservationService.DeleteReservation(request);
            return reservation ? NoContent() : NotFound();
        }
    }

