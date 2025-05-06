using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.CustomerDto.GetCustomerByIdDto;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.CustomerController;
    /// <summary>
    /// Controller responsabile del recupero di un cliente tramite ID.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Customer")]
    public class GetCustomerByIdController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public GetCustomerByIdController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        /// <summary>
        /// Recupera un cliente in base all'ID specificato.
        /// </summary>
        /// <param name="id">ID del cliente da recuperare.</param>
        /// <returns>Il cliente corrispondente oppure un errore se non trovato</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var request = new GetCustomerByIdRequestDto{Id = id};
            var customer = await _customerService.GetCustomerByIdAsync(request);
            return customer is not null ? Ok(customer) : NotFound();
        }
    }

