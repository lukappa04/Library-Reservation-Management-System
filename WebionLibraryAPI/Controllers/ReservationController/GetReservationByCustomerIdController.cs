using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.ReservationDto;
using WebionLibraryAPI.DTO.ReservationDto.GetReservationByCustomerId;
using WebionLibraryAPI.Models.Reservations;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.ReservationController;
    /// <summary>
    /// Controller responsabile del recupero delle prenotazioni associate a un cliente.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Reservation")]
    public class GetReservationByCustomerIdController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public GetReservationByCustomerIdController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        /// <summary>
        ///  Recupera le prenotazioni effettuate da un cliente specifico.
        /// </summary>
        /// <param name="Id">ID del cliente</param>
        /// <returns>Lista di prenotazioni o errore NotFound se non trovate</returns>
        [HttpGet("by-customer/")]
        public async Task<IActionResult> GetByCustomerId(int Id)
        {
            var request = new GetReservationByCustomerIdRequestDto {CustomerId = Id};
            var reservation = await _reservationService.GetReservationByCustomerId(request);
            return reservation is not null ? Ok(reservation) : NotFound();
        }
    }

