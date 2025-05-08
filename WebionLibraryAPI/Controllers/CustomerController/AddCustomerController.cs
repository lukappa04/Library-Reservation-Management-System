using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.CustomerDto.AddCustomerDto;
using WebionLibraryAPI.Exceptions;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.CustomerController;

    /// <summary>
    /// Controller responsabile dell'aggiunta di un nuovo cliente.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Customer")]
    public class AddCustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
         /// <summary>
        /// Costruttore per iniettare il servizio clienti.
        /// </summary>
        /// <param name="customerService">Servizio per la gestione dei clienti.</param>
        public AddCustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        /// <summary>
        /// Aggiunge un nuovo cliente al sistema.
        /// </summary>
        /// <param name="request">I dati del cliente da aggiungere.</param>
        /// <returns>Il cliente appena creato.</returns>
        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerRequestDto request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            try{
            var customer = await _customerService.AddCustomerAsync(request);
            return customer is not null ? Ok(customer) : NotFound();
            }catch(DataAlreadyExistExc)
            {
                return BadRequest("Email già esistente");
            }
        }
    }

