using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using WebionLibraryAPI.DTO.CustomerDto.UpdateCustomerDto;
using WebionLibraryAPI.Exceptions;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.CustomerController;

    /// <summary>
    /// Controller responsabile dell'aggiornamento di un cliente esistente.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Customer")]
    public class UpdateCustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public UpdateCustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        /// <summary>
        /// Aggiorna un cliente esistente in base all'ID specificato.
        /// </summary>
        /// <param name="id">ID del cliente da aggiornare.</param>
        /// <param name="request">Dati aggiornati del cliente.</param>
        /// <returns>Il cliente aggiornato oppure un errore se non trovato.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, UpdateCustomerRequestDto request)
        {
            try{
                var customer = await _customerService.UpdateCustomerAsync(id, request);
                return customer is not null ? Ok(customer) : NotFound();
            }catch(DataAlreadyExistExc)
            {
                return BadRequest("Questa email è già associata ad un altro cliente");
            }
        }
    }

