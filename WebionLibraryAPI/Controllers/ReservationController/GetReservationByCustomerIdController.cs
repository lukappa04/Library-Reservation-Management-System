using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.ReservationDto;
using WebionLibraryAPI.DTO.ReservationDto.GetReservationByCustomerId;
using WebionLibraryAPI.Models.Reservations;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.ReservationController;

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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByCustomerId(int Id)
        {
            var request = new GetReservationByCustomerIdRequestDto {CustomerId = Id};
            var reservation = await _reservationService.GetReservationById(request);
            return reservation is not null ? Ok(reservation) : NotFound();
        }
    }

