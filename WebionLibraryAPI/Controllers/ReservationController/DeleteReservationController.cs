using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.ReservationDto.DeleteReservation;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.ReservationController;

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
        [HttpDelete]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var request = new DeleteReservationRequestDto {BookId = id};
            var reservation = await _reservationService.DeleteReservation(request);
            return reservation ? NoContent() : NotFound();
        }
    }

