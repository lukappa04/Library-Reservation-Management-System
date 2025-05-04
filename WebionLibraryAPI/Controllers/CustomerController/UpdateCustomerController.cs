using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using WebionLibraryAPI.DTO.CustomerDto.UpdateCustomerDto;
using WebionLibraryAPI.Service.Interfaces;

namespace WebionLibraryAPI.Controllers.CustomerController;

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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, UpdateCustomerRequestDto request)
        {
            var customer = await _customerService.UpdateCustomerAsync(id, request);
            return customer is not null ? Ok(customer) : NotFound();
        }
    }

