using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.CustomerDto.AddCustomerDto;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.CustomerController;

    [Route("api/[controller]")]
    [ApiController]
    [Tags("Customer")]
    public class AddCustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public AddCustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerRequestDto request)
        {
            var customer = await _customerService.AddCustomerAsync(request);
            return Ok(customer);
        }
    }

