using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.CustomerController;

    /// <summary>
    /// Controller responsabile del recupero di tutti i clienti.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Customer")]
    public class GetAllCustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public GetAllCustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        /// <summary>
        /// Recupera la lista di tutti i clienti registrati.
        /// </summary>
        /// <returns>Una lista di clienti.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllCustomerAsync();
            return Ok(customers);
        }
    }

