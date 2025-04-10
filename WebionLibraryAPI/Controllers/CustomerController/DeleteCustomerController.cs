using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.CustomerDto.DeleteCustomerDto;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.CustomerController;

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
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var request = new DeleteCustomerRequestDto {Id = id};
            var customer = await _customerService.DeleteCustomerAsync(request);
            return customer ? NoContent() : NotFound();
        }
    }

