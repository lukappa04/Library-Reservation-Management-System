using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebionLibraryAPI.DTO.CustomerDto.GetCustomerByIdDto;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.CustomerController;

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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var request = new GetCustomerByIdRequestDto{Id = id};
            var customer = await _customerService.GetCustomerByIdAsync(request);
            return customer is not null ? Ok(customer) : NotFound();
        }
    }

