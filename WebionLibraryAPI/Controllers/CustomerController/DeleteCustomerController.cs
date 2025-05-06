using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.CustomerDto.DeleteCustomerDto;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.CustomerController;

    /// <summary>
    /// Controller responsabile dell'eliminazione di un cliente.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Customer")]
    public class DeleteCustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public DeleteCustomerController(ICustomerService customerService)
        {
            _customerService = customerService; 
        }
        /// <summary>
        /// Elimina un cliente tramite il suo ID.
        /// </summary>
        /// <param name="id">ID del cliente da eliminare.</param>
        /// <returns>Risultato dell'operazione. In questo caso NoContent se va tutto bene. NotFound se risultano dei problemi</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var request = new DeleteCustomerRequestDto {Id = id};
            var customer = await _customerService.DeleteCustomerAsync(request);
            return customer ? NoContent() : NotFound();
        }
    }

